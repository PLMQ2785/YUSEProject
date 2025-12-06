using UnityEngine;
using System;
using UnityEngine.UI;

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


        //TakeDamage(1); //풀링 테스트 시 순식간에 죽길래 비활성화 하고 테스트 했습니다.
    }

    #endregion


    #region Public Methods

    /// 스폰 시점에 타겟(플레이어)을 주입받는 초기화 메소드
    public void Init(Transform target, Action<Monster> returnToPoolCallback = null)

    {
        _target = target;
        _returnToPoolAction = returnToPoolCallback; // 콜백 저장

        // 재활용될 때 HP를 다시 채워야 합니다!
        _currentHp = maxHp;
        
        // 풀에서 재사용될 때 색상 리셋 (피격 효과 때문에 빨간색일 수 있음)
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _originalColor;
        }
        
        // 실행 중인 모든 코루틴 중지 (HitFlash 등)
        StopAllCoroutines();
        
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
        
        // 색상 리셋 (풀로 반환되기 전에)
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _originalColor;
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