/*
 * [PlayerManager.cs]
 * [패키지 2] 플레이어 로직
 * Sprint 1 목표(B-1.a)에 따라 이동, HP 관리, 사망 처리,
 * 그리고 HUD 연동을 위한 OnHpChanged 이벤트를 구현합니다.
 *
 * 이 스크립트는 '통합 코딩 컨벤션'을 완벽하게 준수하여 작성되었습니다.
 */

using System;
using System.Collections.Generic; // event Action 사용
using UnityEngine;

// 코딩 컨벤션 1-4 (GetComponent)를 위해 Rigidbody2D 강제
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    #region Events
    // (Sprint 1, B-1.a) HP 변경 이벤트 정의 (HUDManager가 구독할 대상)
    public event Action<float, float> OnHpChanged;
    // (Sprint 2, D-1.b) 경험치 변경 이벤트 정의
    public event Action<float, float> OnExpChanged;
    // 재화, 킬 카운트 변경 이벤트 정의
    public event Action<int> OnGoldChanged;
    public event Action<int> OnKillCountChanged;
    
    // (Sprint 2, B-1.b) 레벨 업 이벤트를 정의합니다. (GameManager가 구독할 대상)
    public event Action OnPlayerLeveledUp;

    //보물상자 먹는 이벤트
    public event Action OnPlayerGetTreasure;
    #endregion

    #region Properties
    // 외부에서 현재 HP를 읽을 수 있도록 프로퍼티로 노출
    public float CurrentHp { get => _currentHp; }
    // (Sprint 2 추가) 레벨, 경험치, 골드, 킬카운트 프로퍼티
    public int Level { get => _level; }
    public int CurrentExp { get => _currentExp; }
    public int MaxExp { get => _maxExp; }
    public int Gold { get => _gold; }
    public int KillCount { get => _killCount; }

    //위치
    public Vector2 Player_Position =>transform.position;

    // PlayerStats에 외부에서 접근할 수 있게 노출
    public PlayerStats Stats => stats;
    
    // (Sprint 2 추가) 바라보는 방향 (기본값: 오른쪽)
    public Vector2 FacingDirection { get; private set; } = Vector2.right;
    
    // 충돌 데미지 무적 상태 확인
    public bool IsInvincibleFromContact => _contactDamageTimer > 0f;
    
    // 대시 상태 확인
    public bool IsDashing => _isDashing;
    #endregion
    
    #region Serialized Fields
    [Header("Dependencies (Required)")]
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private InventoryManager inventoryManager; // (Sprint 2) 장비 관리자 추가
    
    [Header("Starting Equipment")]
    [SerializeField] 
    private WeaponData startingWeapon;

    [Header("Stats")]
    [SerializeField]
    private PlayerStats stats;
    
    [Header("Contact Damage Settings")]
    [SerializeField]
    private float contactDamageCooldown = 1f; // 충돌 데미지 쿨다운 (무적시간)
    
    [Header("Dash Settings")]
    [SerializeField]
    private float dashDistance = 5f; // 대시 거리
    [SerializeField]
    private float dashDuration = 0.2f; // 대시 지속 시간
    [SerializeField]
    private float dashCooldown = 2f; // 대시 쿨다운
    
    [Header("Dash Damage Settings")]
    [SerializeField]
    private float dashDamage = 10f; // 대시 데미지
    [SerializeField]
    private float dashDamageRadius = 0.8f; // 대시 데미지 탐지 반경
    [SerializeField]
    private GameObject lightningEffectPrefab; // 번개 이펙트 프리팫
    #endregion

    #region Private Fields
    private UpgradeManager _upgradeManager; // 업그레이드 매니저
    private Rigidbody2D _rb;
    private float _currentHp;
    private Animator _anime;
    private SpriteRenderer _sprite;
    
    // --- Sprint 2에서 사용할 변수 ---
    private int _level = 1;
    private int _currentExp = 0;
    private int _maxExp = 100; // 초기 최대 경험치
    private int _gold = 0;
    private int _killCount = 0;
    
    // --- 충돌 데미지 관련 ---
    private float _contactDamageTimer = 0f; // 충돌 데미지 쿨다운 타이머
    private Coroutine _invincibilityFlashCoroutine; // 깜빡임 코루틴 참조
    private Color _originalSpriteColor; // 원래 스프라이트 색상
    
    // --- 대시 관련 ---
    private bool _isDashing = false; // 현재 대시 중인지 여부
    private float _dashCooldownTimer = 0f; // 대시 쿨다운 타이머
    private Vector2 _lastMoveDirection = Vector2.right; // 마지막 이동 방향 (정지 시 대시용)
    private int _originalLayer; // 원래 레이어 저장
    #endregion

    #region Unity LifeCycle
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anime = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        
        _currentHp = stats.MaxHp;
        
        // 원래 스프라이트 색상 저장
        if (_sprite != null)
        {
            _originalSpriteColor = _sprite.color;
        }
        
        // 원래 레이어 저장
        _originalLayer = gameObject.layer;
    }


    private void Update()
    {
        Player_Animation();
        
        // 충돌 데미지 쿨다운 타이머 감소
        if (_contactDamageTimer > 0f)
        {
            _contactDamageTimer -= Time.deltaTime;
        }
        
        // 대시 쿨다운 타이머 감소
        if (_dashCooldownTimer > 0f)
        {
            _dashCooldownTimer -= Time.deltaTime;
        }
        
        // 대시 입력 체크
        if (!_isDashing && inputManager.DashTriggered && _dashCooldownTimer <= 0f)
        {
            TryDash();
        }
    }
    private void Start()
    {
        // UpgradeManager로부터 보너스 적용
        ApplyUpgradeBonuses();
        
        // 안전 장치
        if (inputManager == null)
        {
            Debug.LogError("PlayerManager: InputManager가 인스펙터에 할당되지 않았습니다!");
        }
        
        // InventoryManager 초기화
        if (inventoryManager != null)
        {
            inventoryManager.Initialize(this);
        }
        else
        {
            // 인스펙터에 할당되지 않았을 경우, 같은 오브젝트에서 찾아보기
            inventoryManager = GetComponent<InventoryManager>();
            if (inventoryManager != null)
            {
                inventoryManager.Initialize(this);
            }
            else
            {
                Debug.LogWarning("PlayerManager: InventoryManager가 할당되지 않았습니다.");
            }
        }

        // InputManager 이벤트 구독
        if (inputManager != null)
        {
            inputManager.GetItemUseInput += HandleItemUseInput;
        }
        
        // 기본 무기 지급
        EquipStartingWeapon();
    }

    private void OnDestroy()
    {
        if (inputManager != null)
        {
            inputManager.GetItemUseInput -= HandleItemUseInput;
        }
    }

    // 물리 업데이트는 FixedUpdate에서 처리
    private void FixedUpdate()
    {
        // 대시 중에는 일반 이동 중단
        if (_isDashing)
        {
            return;
        }
        
        // (Sprint 1, B-1.a) InputManager에서 이동 값을 받아 Move 함수 호출
        Vector2 moveInput = new Vector2(
            inputManager.HorizontalInputValue,
            inputManager.VerticalInputValue
        );

        // 입력이 있을 때만 바라보는 방향 업데이트 및 정규화
        if (moveInput.sqrMagnitude > 0.01f)
        {
            moveInput.Normalize(); // 대각선 이동 속도 보정
            FacingDirection = moveInput;
            _lastMoveDirection = moveInput; // 대시용으로 마지막 이동 방향 저장
        }

        Move(moveInput);
    }
    
    /// <summary>
    /// InputManager로부터 아이템 사용 입력을 받을 때 호출됩니다.
    /// </summary>
    private void HandleItemUseInput(int slotNumber)
    {
        if (GameManager.Instance.CurrentState != GameState.Playing)
        {
            return;
        }
        
        // 슬롯 번호는 1, 2, 3 ... -> 인덱스 0, 1, 2 ...
        if (inventoryManager != null)
        {
            inventoryManager.UseItem(slotNumber - 1);
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// (B-1.a) 캐릭터의 HP를 감소시킵니다. (Monster가 호출)
    /// </summary>
    /// <param name="amount">받은 데미지 양</param>
    public void TakeDamage(float amount)
    {
        TakeDamage(amount, false);
    }
    
    /// <summary>
    /// 캐릭터의 HP를 회복시킵니다.
    /// </summary>
    /// <param name="amount">회복할 HP 양</param>
    public void Heal(float amount)
    {
        if (amount <= 0) return;
        
        _currentHp += amount;
        
        // 최대 HP를 초과하지 않도록 제한
        if (_currentHp > stats.MaxHp)
        {
            _currentHp = stats.MaxHp;
        }
        
        // HP 변경 이벤트 발생
        OnHpChanged?.Invoke(_currentHp, stats.MaxHp);
        
        Debug.Log($"HP {amount} 회복! (현재: {_currentHp}/{stats.MaxHp})");
    }
    
    /// <summary>
    /// 캐릭터의 HP를 감소시킵니다. 충돌 데미지 여부를 지정할 수 있습니다.
    /// </summary>
    /// <param name="amount">받은 데미지 양</param>
    /// <param name="isContactDamage">몬스터 충돌 데미지인지 여부</param>
    public void TakeDamage(float amount, bool isContactDamage)
    {
        if (_currentHp <= 0) return; // 이미 사망함
        
        // 충돌 데미지이고 무적 상태라면 무시
        if (isContactDamage && IsInvincibleFromContact)
        {
            return;
        }

        _currentHp -= amount * (1 - stats.DamageReductionMult);
        
        // 충돌 데미지를 받았다면 쿨다운 타이머 설정 + 깜빡임 효과
        if (isContactDamage)
        {
            _contactDamageTimer = contactDamageCooldown;
            
            // 이전 깜빡임 코루틴 중지 후 새로 시작
            if (_invincibilityFlashCoroutine != null)
            {
                StopCoroutine(_invincibilityFlashCoroutine);
                _sprite.color = _originalSpriteColor; // 색상 복원
            }
            _invincibilityFlashCoroutine = StartCoroutine(InvincibilityFlashCoroutine());
        }

        // (Sprint 1, B-1.a) HP가 변경되었음을 모든 구독자(HUDManager 등)에게 "방송"
        OnHpChanged?.Invoke(_currentHp, stats.MaxHp);

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            Die();
        }
    }
    
    /// <summary>
    /// (S2, B-1.b) 경험치를 획득합니다.
    /// </summary>
    /// <param name="amount">획득한 경험치 양</param>
    public void GainExp(int amount)
    {
        _currentExp += (int)(amount * stats.ExpMult);
        
        // 경험치 획득 후 UI 갱신 알림
        OnExpChanged?.Invoke((float)_currentExp, (float)_maxExp);

        if (_currentExp >= _maxExp)
        {
            LevelUp();
        }
    }

    /// <summary>
    /// (S2, B-1.c) 재화를 획득합니다.
    /// </summary>
    /// <param name="amount">획득한 재화 양</param>
    public void GainGold(int amount)
    {
        _gold += (int)(amount * stats.GoldMult);
        
        // 재화 획득 후 UI 갱신 알림
        OnGoldChanged?.Invoke(_gold);
    }
    
    /// <summary>
    /// 골드를 소비합니다 (배수 적용 없이 정확한 금액만 차감)
    /// </summary>
    /// <param name="amount">소비할 골드 양</param>
    /// <returns>성공 여부 (골드가 부족하면 false)</returns>
    public bool SpendGold(int amount)
    {
        if (_gold < amount)
        {
            return false;
        }
        
        _gold -= amount;
        OnGoldChanged?.Invoke(_gold);
        return true;
    }
    
    //보물상자 획득
    public void GainTreasure()
    {
        OnPlayerGetTreasure?.Invoke();
    }



    /// <summary>
    /// 킬카운트를 획득합니다.
    /// </summary>
    /// <param name="amount">획득한 킬카운트</param>
    public void GainKillCount(int amount)
    {
        _killCount += amount;
        OnKillCountChanged?.Invoke(_killCount);
    }

    /// <summary>
    /// 장비 획득 시 호출
    /// </summary>
    public void AddEquipment(EquipmentData data)
    {
        if (inventoryManager != null)
        {
            Debug.Log("PlayerManager.AddEquipment(EquipmentData data) 진입");
            inventoryManager.Add(data);
        }
    }

    public void AddItem(ItemData data)
    {
        if (inventoryManager != null)
        {
            inventoryManager.Add(data);
        }
    }
    
    /// <summary>
    /// 패시브 아이템 보너스를 추가합니다.
    /// </summary>
    public void AddPassiveBonus(UpgradeType type, object source, float value)
    {
        stats.SetPassiveBonus(type, source, value);
    }

    // public void SpendGold(int amount) { ... }
    
    // EventManager가 호출 -> 일시적 스탯 변동 적용
    public void ApplyEventModifiers(object eventSource, List<StatModifier> modifiers)
    {
        foreach (var mod in modifiers)
        {
            // PlayerStats에 새로 만든 이벤트적용 메서드 호출
            stats.AddEventBonus(mod.statType, eventSource, mod.value);
            
            Debug.Log($"[Event Buff] {mod.statType} += {mod.value}");
        }
        // 필요하면 여기서 이동속도 즉시 갱신 코드 작성!
    }
    
    // EventManager가 호출함 -> 일시적 스탯 변동 해제
    public void RemoveEventModifiers(object eventSource, List<StatModifier> modifiers)
    {
        foreach (var mod in modifiers)
        {
            // PlayerStats에 새로 만든 이벤트제거 메서드 호출
            stats.RemoveEventBonus(mod.statType, eventSource);
            
            Debug.Log($"[Event End] {mod.statType} -= {mod.value} (복구됨)");
        }
    }

    /// <summary>
    /// 패시브 아이템 보너스를 제거합니다.
    /// </summary>
    public void RemovePassiveBonus(UpgradeType type, object source)
    {
        stats.RemovePassiveBonus(type, source);
    }
    
    #endregion

    #region Private Methods
    /// <summary>
    /// 게임 시작 시 기본 무기를 지급합니다.
    /// </summary>
    private void EquipStartingWeapon()
    {
        if (startingWeapon != null && inventoryManager != null)
        {
            inventoryManager.Add(startingWeapon);
            Debug.Log($"Starting weapon equipped: {startingWeapon.EquipmentName}");
        }
        else if (startingWeapon == null)
        {
            Debug.LogWarning("PlayerManager: 시작 무기가 할당되지 않았습니다. Inspector에서 Starting Weapon을 설정해주세요.");
        }
    }
    
    /// <summary>
    /// (B-1.a) SDS 3.2.2에 정의된 Move 함수 (내부 로직)
    /// </summary>
    private void Move(Vector2 direction)
    {
        // (Sprint 1, B-1.a) Rigidbody.MovePosition 사용
        Vector2 newPosition = _rb.position + direction * (stats.Speed * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);
    }

    /// <summary>
    /// (B-1.a) SDS 3.2.2에 정의된 Die 함수 (내부 로직)
    /// </summary>
    private void Die()
    {
        // (Sprint 1, B-1.a) 사망 처리
        Debug.Log("Player has died.");

        // (Sprint 3, A-2.b) GameManager에게 사망을 알림
        // (코딩 컨벤션 1-2: GameManager는 싱글톤으로 접근)
        GameManager.Instance.GameOver(); 
        
        // 우선은 플레이어 비활성화
        gameObject.SetActive(false); 
    }
    

    private void Player_Animation()
    {
        float input_x = inputManager.HorizontalInputValue;
        float input_y=inputManager.VerticalInputValue;

        bool isMoving;
        Vector2 moveinput = new Vector2(input_x, input_y);

        if(moveinput!=Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        _anime.SetBool("IsWalk", isMoving);

        if(input_x!=0)
        {
            _sprite.flipX = input_x > 0;
        }

    }


    /// <summary>
    /// (S2, B-1.b) 레벨 업 처리
    /// </summary>
    private void LevelUp()
    {
        // 경험치 이월 및 레벨 증가
        _currentExp -= _maxExp;
        _level++;
        
        // 다음 레벨 필요 경험치 증가 (예: 20% 증가)
        _maxExp = Mathf.RoundToInt(_maxExp * 1.2f);
        
        // 레벨 업 시 최대 체력의 20% 회복
        Heal(stats.MaxHp * 0.2f);
        
        // 레벨 업 후에도 남은 경험치가 최대 경험치보다 많을 수 있으므로 재귀 호출 가능성 고려
        // (단순화를 위해 여기서는 한 번만 처리하거나 while문 사용 가능)
        
        // 레벨 업 후 UI 갱신 알림 (변경된 maxExp 반영)
        OnExpChanged?.Invoke((float)_currentExp, (float)_maxExp);

        // GameManager 등에게 레벨 업 사실 알림
        OnPlayerLeveledUp?.Invoke(); 
    }
    
    /// <summary>
    /// UpgradeManager로부터 보너스를 받아와 PlayerStats에 적용합니다.
    /// </summary>
    private void ApplyUpgradeBonuses()
    {
        Debug.Log("[PlayerManager] ApplyUpgradeBonuses() 시작");
        
        if (_upgradeManager == null)
        {
            _upgradeManager = UpgradeManager.Instance;
        }
    
        if (_upgradeManager == null)
        {
            Debug.LogWarning("PlayerManager: UpgradeManager를 찾을 수 없습니다. 보너스가 적용되지 않습니다.");
            return;
        }
    
        Debug.Log($"[PlayerManager] UpgradeManager.AvailableUpgrades.Count = {_upgradeManager.AvailableUpgrades.Count}");
        
        // 모든 UpgradeType에 대해 보너스 적용
        foreach (UpgradeType type in System.Enum.GetValues(typeof(UpgradeType)))
        {
            float bonus = _upgradeManager.GetStatBonus(type);
            Debug.Log($"[PlayerManager] {type} 보너스 조회 결과 = {bonus}");
            if (bonus > 0)
            {
                stats.SetPermanentBonus(type, bonus);
                Debug.Log($"PlayerManager: {type} 보너스 적용 (+{bonus})");
            }
        }
        
        Debug.Log("[PlayerManager] ApplyUpgradeBonuses() 완료");
    }
    
    /// <summary>
    /// 대시를 시도합니다.
    /// </summary>
    private void TryDash()
    {
        if (_isDashing || _dashCooldownTimer > 0f)
        {
            return;
        }
        
        // 대시 방향은 마지막 이동 방향 사용
        Vector2 dashDirection = _lastMoveDirection.normalized;
        
        StartCoroutine(DashCoroutine(dashDirection));
    }
    
    /// <summary>
    /// 대시 코루틴: 일정 거리를 빠르게 이동하며 몬스터를 뚚고 지나갑니다.
    /// </summary>
    private System.Collections.IEnumerator DashCoroutine(Vector2 direction)
    {
        _isDashing = true;
        _dashCooldownTimer = dashCooldown;
        
        // 대시 중 피해를 입힌 적 추적 (중복 피해 방지)
        HashSet<Monster> damagedMonsters = new HashSet<Monster>();
        
        // Rigidbody2D를 kinematic으로 전환하여 적을 밀지 않도록 함
        bool wasKinematic = _rb.isKinematic;
        _rb.isKinematic = true;
        
        // 몬스터 레이어와의 충돌 무시 설정
        int monsterLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(_originalLayer, monsterLayer, true);
        
        float elapsedTime = 0f;
        Vector2 startPosition = _rb.position;
        Vector2 targetPosition = startPosition + direction * dashDistance;
        
        // 대시 이동
        while (elapsedTime < dashDuration)
        {
            elapsedTime += Time.fixedDeltaTime;
            float t = elapsedTime / dashDuration;
            
            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, t);
            _rb.MovePosition(newPosition);
            
            // 대시 경로의 적 탐지 및 피해 적용
            DealDashDamage(damagedMonsters);
            
            yield return new WaitForFixedUpdate();
        }
        
        // 대시 종료
        _rb.MovePosition(targetPosition);
        
        // 번개 이펙트 생성 (출발지점 -> 도착지점)
        SpawnLightningEffect(startPosition, targetPosition);
        
        // Rigidbody2D를 원래 상태로 복구
        _rb.isKinematic = wasKinematic;
        
        // 몬스터와의 충돌 무시 해제
        Physics2D.IgnoreLayerCollision(_originalLayer, monsterLayer, false);
        
        _isDashing = false;
    }
    
    /// <summary>
    /// 대시 경로의 적에게 피해를 입힙니다.
    /// </summary>
    private void DealDashDamage(HashSet<Monster> damagedMonsters)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position, 
            dashDamageRadius, 
            LayerMask.GetMask("Enemy"));
        
        foreach (var hit in hits)
        {
            Monster monster = hit.GetComponent<Monster>();
            if (monster != null && !damagedMonsters.Contains(monster))
            {
                monster.TakeDamage(dashDamage);
                damagedMonsters.Add(monster);
                Debug.Log($"Dash damage dealt to {monster.name}: {dashDamage}");
            }
        }
    }
    
    /// <summary>
    /// 대시 경로에 번개 이펙트를 생성합니다.
    /// </summary>
    private void SpawnLightningEffect(Vector2 startPos, Vector2 endPos)
    {
        if (lightningEffectPrefab == null) return;
        
        // 중간 지점 계산
        Vector2 midPoint = (startPos + endPos) / 2f;
        
        // 방향 및 각도 계산
        Vector2 direction = endPos - startPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // 이펙트 생성 (회전 적용)
        GameObject effect = Instantiate(
            lightningEffectPrefab, 
            midPoint, 
            Quaternion.Euler(0, 0, angle));
        
        // 거리에 맞게 스케일 조정 (X 축으로 늘리기)
        float distance = direction.magnitude;
        Vector3 scale = effect.transform.localScale;
        scale.x = distance;
        effect.transform.localScale = scale;
        
        // ParticleSystem 설정 수정 (1번만 재생)
        var particleSystem = effect.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            var main = particleSystem.main;
            main.loop = false; // 루프 중지
            
            // 이펙트 지속 시간 후 자동 삭제
            float duration = main.duration + main.startLifetime.constantMax;
            Destroy(effect, duration);
        }
        else
        {
            // ParticleSystem이 없으면 1초 후 삭제
            Destroy(effect, 1f);
        }
    }

    /// <summary>
    /// 무적 시간 동안 플레이어를 깜빡이게 합니다 (투명도 변경).
    /// </summary>
    private System.Collections.IEnumerator InvincibilityFlashCoroutine()
    {
        if (_sprite == null)
        {
            Debug.LogError("[InvincibilityFlash] _sprite is null!");
            yield break;
        }
        
        float flashInterval = 0.1f; // 깜빡임 간격
        Color flashColor = new Color(_originalSpriteColor.r, _originalSpriteColor.g, _originalSpriteColor.b, 0.3f); // 반투명
        
        while (_contactDamageTimer > 0f)
        {
            // 반투명으로 변경
            _sprite.color = flashColor;
            yield return new WaitForSeconds(flashInterval);
            
            // 원래 색으로 복원
            _sprite.color = _originalSpriteColor;
            yield return new WaitForSeconds(flashInterval);
        }
        
        // 최종적으로 원래 색으로 복원
        _sprite.color = _originalSpriteColor;
        _invincibilityFlashCoroutine = null; // 코루틴 참조 정리
    }
 
    #endregion
}