using UnityEngine;
using System.Collections.Generic;

public class HoshinGanggi : Weapon
{
    #region Serialized Fields
    [Header("호신강기 설정")]
    [SerializeField] private float auraRadius = 3f;           // 강기 범위
    [SerializeField] private float dotDamageInterval = 0.5f;  // 도트 간격 (초)
    [SerializeField] private float slowAmount = 0.3f;         // 30% 감속
    [SerializeField] private float debuffDuration = 0.6f; 
    
    [Header("시각 효과")]
    [SerializeField] private SpriteRenderer auraRenderer;    // 디버프 지속 시간
    #endregion

    #region Private Fields
    private CircleCollider2D _auraCollider;
    private List<Monster> _monstersInAura = new List<Monster>();
    private float _dotTimer = 0f;
    #endregion

    #region Unity LifeCycle
    protected void Start()
    {
        // 필요하면 여기서 추가 초기화
    }

    public override void Initialize(PlayerManager player, EquipmentData data)
    {
        base.Initialize(player, data);

        // CircleCollider2D 자동 생성 또는 찾기
        _auraCollider = GetComponent<CircleCollider2D>();
        if (_auraCollider == null)
        {
            _auraCollider = gameObject.AddComponent<CircleCollider2D>();
        }

        // 콜라이더 설정
        _auraCollider.isTrigger = true;
        _auraCollider.radius = auraRadius;

        // 플레이어 위치에 붙이기 (혹시 부모 설정 안 되어 있으면)
        if (_player != null)
        {
            transform.SetParent(_player.transform);
            transform.localPosition = Vector3.zero;
        }
    }

    protected override void Update()
    {
        base.Update(); // Weapon 쿨다운 등 기본 처리

        // 혹시 부모로 안 붙었을 경우 대비용 (옵션)
        if (_player != null)
        {
            transform.position = _player.transform.position;
        }

        // 도트 데미지 타이머
        _dotTimer += Time.deltaTime;
        if (_dotTimer >= dotDamageInterval)
        {
            _dotTimer = 0f;
            ApplyDotDamageToAll();
        }
    }
    #endregion

    #region Trigger Events
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Monster monster = other.GetComponent<Monster>();
        if (monster != null && !_monstersInAura.Contains(monster))
        {
            _monstersInAura.Add(monster);
            // 범위 진입 시 바로 감속 디버프 적용
            monster.ApplySpeedDebuff(this, slowAmount, debuffDuration);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Monster monster = other.GetComponent<Monster>();
        if (monster != null && _monstersInAura.Contains(monster))
        {
            _monstersInAura.Remove(monster);
            // 범위를 벗어나면 이 무기가 건 디버프 제거
            monster.RemoveSpeedDebuff(this);
        }
    }

    private void OnDisable()
    {
        // 무기 사라질 때 이 무기가 걸어둔 슬로우 정리
        for (int i = 0; i < _monstersInAura.Count; i++)
        {
            if (_monstersInAura[i] != null)
            {
                _monstersInAura[i].RemoveSpeedDebuff(this);
            }
        }
        _monstersInAura.Clear();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// 범위 내 모든 몬스터에게 도트 데미지 + 감속 갱신
    /// (리스트 스냅샷을 사용하여 도중 변경으로 인한 인덱스 에러 방지)
    /// </summary>
    private void ApplyDotDamageToAll()
    {
        if (_monstersInAura.Count == 0)
            return;

        // 리스트의 현재 상태를 스냅샷으로 복사
        Monster[] snapshot = _monstersInAura.ToArray();

        foreach (var monster in snapshot)
        {
            if (monster == null)
            {
                _monstersInAura.Remove(monster);
                continue;
            }

            // 데미지 계산 (WeaponData + 레벨 + 플레이어 공격력 반영)
            float damage = WeaponData != null ? WeaponData.BaseDamage : 5f;
            damage += (_level - 1) * 5f; // 레벨 당 5 증가 (원하는 대로 조정 가능)

            if (_player != null)
            {
                damage *= _player.Stats.AttackDamageMult;
            }

            monster.TakeDamage(damage);

            // 여전히 범위 안에 있는 동안은 디버프 시간 갱신 (중첩 X, 타이머 리셋)
            monster.ApplySpeedDebuff(this, slowAmount, debuffDuration);
        }

        // 혹시 null 생긴 항목들 깔끔하게 제거
        _monstersInAura.RemoveAll(m => m == null);
    }
    #endregion

    #region Weapon Overrides
    protected override void PerformAttack()
    {
        // 지속형 무기라 별도 발사 없음
        // 필요하면 여기서 일시적인 효과(범위 확장 등) 넣어도 됨
    }

    public override void LevelUp()
    {
        base.LevelUp();

        // 레벨업 시 스탯 강화
        auraRadius += 0.5f;
        slowAmount = Mathf.Min(slowAmount + 0.05f, 0.9f); // 감속량 5% 증가, 최대 90%

        // 콜라이더 범위도 업데이트
        if (_auraCollider != null)
        {
            _auraCollider.radius = auraRadius;
        }
    }
    #endregion
}
