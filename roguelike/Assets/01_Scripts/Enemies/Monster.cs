using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

/// 모든 몬스터의 기본이 되는 추상 클래스
/// SDS의 Monster 명세(HP, Move, TakeDamage, Die)대로 일단 만듬
public abstract class Monster : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] protected string monsterName;
    [SerializeField][TextArea] private string description;
    [SerializeField] protected bool unlocked;


    [Header("Stats")] [SerializeField] protected float maxHp = 10f;
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float contactDamage = 5f; // 플레이어와 충돌 시 데미지
    
    [Header("Spawn Effects")]
    [SerializeField] protected float fadeInDuration = 0.5f; // 스폰 시 페이드인 소요 시간

    #endregion

    public string MonsterName => monsterName;
    public string Description => description;
    // SpriteRenderer의 sprite를 직접 가져오기 (프리펛 상태에서도 동작)
    public Sprite Icon
    {
        get
        {
            var renderer = GetComponent<SpriteRenderer>();
            return renderer != null ? renderer.sprite : null;
        }
    }

    public GameObject expOrbPrefab;

    public bool Unlocked { get => unlocked; set => unlocked = value; }

    #region Private Fields

    protected float _currentHp;
    protected Transform _target; // 플레이어(추적 대상)

    // 몬스터가 죽었을 때 호출할 콜백 -> 풀로 복귀
    protected Action<Monster> _returnToPoolAction;
    
    // 피격 효과용
    protected SpriteRenderer _spriteRenderer;
    protected Color _originalColor;

    // ===== [감속 디버프 시스템 추가] =====
    protected float _speedMultiplier = 1f;

    private class SpeedDebuff
    {
        public float slowAmount;   // 0.3f = 30% 감속
        public float remaining;    // 남은 시간(초)
    }

    private readonly Dictionary<object, SpeedDebuff> _speedDebuffs 
        = new Dictionary<object, SpeedDebuff>();

    #endregion


    #region Unity LifeCycle

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            _originalColor = _spriteRenderer.color;
        }
    }


    protected virtual void Start()
    {
        _currentHp = maxHp;
    }


    protected virtual void Update()
    {
        if (_target != null)
        {
            // 매 프레임 타겟 방향으로 이동
            Move(_target.position);   
        }
        // 감속 디버프 시간 감소 및 배율 재계산
        UpdateSpeedDebuffs();

        //TakeDamage(1); //풀링 테스트 시 순식간에 죽길래 비활성화 하고 테스트 했습니다.
    }

    #endregion

    protected float CurrentMoveSpeed => moveSpeed * _speedMultiplier;

    #region Public Methods

    /// 스폰 시점에 타겟(플레이어)을 주입받는 초기화 메소드
    public void Init(Transform target, Action<Monster> returnToPoolCallback = null)
    {
        _target = target;
        _returnToPoolAction = returnToPoolCallback; // 콜백 저장

        // 재활용될 때 HP를 다시 채워야 합니다!
        _currentHp = maxHp;
        
        // 실행 중인 모든 코루틴 중지 (HitFlash 등)
        StopAllCoroutines();
        
        // 스폰 시 투명도 0에서 시작하여 페이드인
        if (_spriteRenderer != null)
        {
            Color startColor = _originalColor;
            startColor.a = 0f;
            _spriteRenderer.color = startColor;
            
            // 페이드인 시작
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(SpawnFadeIn());
            }
        }
        
        // 콜라이더 재활성화 (Die()에서 비활성화되었을 수 있음)
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = true;
        }
    }


    public virtual void TakeDamage(float amount)

    {
        _currentHp -= amount;
        
        // GameObject가 활성화 상태일 때만 코루틴 실행 (풀링 시스템 대응)
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(HitFlash());
        }

        // TODO: 데미지 표시 UI 로직 추가 하기
        if (_currentHp <= 0)
        {
            Die();
        }
    }

    public abstract void Move(Vector2 targetPosition);


    public virtual void Die()
    {
        // 실행 중인 코루틴 중지 (HitFlash 등)
        StopAllCoroutines();
        
        // 풀 반환 전 투명도를 0으로 리셋 (다음 스폰 시 페이드인 준비)
        if (_spriteRenderer != null)
        {
            Color resetColor = _originalColor;
            resetColor.a = 0f;
            _spriteRenderer.color = resetColor;
        }
        
        // 콜라이더 즉시 비활성화하여 추가 충돌 방지 (풀링 race condition 대응)
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        
        // 사망 처리 (보상 드롭 등 나중에 추가하기)
        DropExpOrb();
        UpGold(1);
        UpKillCount(1);
        
        // Unlock 처리 - LootDataBase를 통해 중앙 관리
        if (LootDataBase.Instance != null)
        {
            Debug.Log($"Monster.Die(): Attempting to unlock monster: {monsterName}");
            LootDataBase.Instance.UnlockMonster(monsterName);
        }
        else
        {
            Debug.LogError("Monster.Die(): LootDataBase.Instance is null!");
        }


        // 수정.. Destroy 대신 풀로 반환 로직 실행
        if (_returnToPoolAction != null)
        {
            _returnToPoolAction.Invoke(this); // 나를 풀로 돌려보냄
        }
        else
        {
            // 콜백이 없으면 그냥 파괴
            Destroy(gameObject);
        }
    }


    public void DropExpOrb()
{
    if (expOrbPrefab == null)
        return;

    GameObject orbObj;

    if (PoolManager.Instance != null)
    {
        // 1) 풀에서 구슬 하나 꺼내오기
        orbObj = PoolManager.Instance.Get(
            expOrbPrefab,
            transform.position,
            Quaternion.identity
        );
    }
    else
    {
        // 2) 혹시 PoolManager가 없으면 그냥 Instantiate
        orbObj = Instantiate(expOrbPrefab, transform.position, Quaternion.identity);
    }

    // 3) ExperienceOrb 컴포넌트 찾아서, 어떤 프리팹에서 나왔는지 알려주기
    ExperienceOrb orb = orbObj.GetComponent<ExperienceOrb>();
    if (orb != null)
    {
        orb.Init(expOrbPrefab);
    }
}

    //일단 죽으면 플레이어의 골드 증가
    public void UpGold(int amount)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Player.GainGold(amount);
        }
    }

    // 죽으면 플레이어의 킬카운트 증가
    public void UpKillCount(int amount)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Player.GainKillCount(amount);
        }
    }
    // ===== [감속 디버프용 Public API] =====

    /// <summary>
    /// 속도 디버프 적용 (slowAmount: 0.3f = 30% 감속, duration: 유지 시간(초))
    /// 같은 source에서 여러 번 호출되면 → 중첩 없이 타이머만 갱신됨.
    /// </summary>
    public void ApplySpeedDebuff(object source, float slowAmount, float duration)
    {
        if (_speedDebuffs.TryGetValue(source, out var debuff))
        {
            // 이미 같은 source에서 디버프가 있다면 → 더 강한 값으로 갱신 가능
            debuff.slowAmount = Mathf.Max(debuff.slowAmount, slowAmount);
            debuff.remaining = duration;   // 🔁 도트 들어올 때마다 시간 리셋
        }
        else
        {
            _speedDebuffs[source] = new SpeedDebuff
            {
                slowAmount = slowAmount,
                remaining = duration
            };
        }

        RecalculateSpeedMultiplier();
    }

    /// <summary>
    /// 특정 source에서 건 디버프 제거 (예: 무기 사라질 때 / 범위 완전 벗어났을 때)
    /// </summary>
    public void RemoveSpeedDebuff(object source)
    {
        if (_speedDebuffs.Remove(source))
        {
            RecalculateSpeedMultiplier();
        }
    }

    #endregion
    
    #region Private Methods
    
    /// <summary>
    /// 피격 시 빨간색으로 깜빡이는 효과
    /// </summary>
    protected System.Collections.IEnumerator HitFlash()
    {
        if (_spriteRenderer != null)
        {
            // 빨간색으로 변경
            _spriteRenderer.color = Color.red;
            
            // 0.1초 대기
            yield return new WaitForSeconds(0.1f);
            
            // 원래 색으로 복구
            _spriteRenderer.color = _originalColor;
        }
    }
    
    /// <summary>
    /// 스폰 시 투명도 0에서 1로 페이드인하는 효과
    /// </summary>
    protected System.Collections.IEnumerator SpawnFadeIn()
    {
        if (_spriteRenderer == null) yield break;
        
        float elapsed = 0f;
        Color color = _originalColor;
        
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeInDuration);
            color.a = alpha;
            _spriteRenderer.color = color;
            yield return null;
        }
        
        // 최종적으로 원래 색상(알파 포함)으로 확정
        _spriteRenderer.color = _originalColor;
    }
    
     /// <summary>
    /// 감속 디버프 남은 시간을 줄이고, 만료된 디버프는 제거합니다.
    /// </summary>
    private void UpdateSpeedDebuffs()
    {
        if (_speedDebuffs.Count == 0)
        {
            _speedMultiplier = 1f;
            return;
        }

        var keys = new List<object>(_speedDebuffs.Keys);
        foreach (var key in keys)
        {
            var debuff = _speedDebuffs[key];
            debuff.remaining -= Time.deltaTime;
            if (debuff.remaining <= 0f)
            {
                _speedDebuffs.Remove(key);
            }
        }

        RecalculateSpeedMultiplier();
    }

    /// <summary>
    /// 현재 활성화된 디버프들을 바탕으로 속도 배율을 재계산합니다.
    /// (여기서는 가장 강한 감속만 적용: max slow)
    /// </summary>
    private void RecalculateSpeedMultiplier()
    {
        float maxSlow = 0f;

        foreach (var debuff in _speedDebuffs.Values)
        {
            if (debuff.slowAmount > maxSlow)
                maxSlow = debuff.slowAmount;
        }

        _speedMultiplier = 1f - Mathf.Clamp01(maxSlow); // slow=0.3 → 배율 0.7
    }

    #endregion
    
    #region Collision
    
    /// <summary>
    /// 플레이어와 충돌 중일 때 데미지를 줍니다.
    /// </summary>
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        // 플레이어와 충돌 확인
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
        if (player != null)
        {
            // 충돌 데미지 적용 (무적 시스템이 자동으로 처리)
            player.TakeDamage(contactDamage, true);
        }
    }
    
    #endregion
}