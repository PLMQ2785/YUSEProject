/*
 * [BottleProjectile.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 수직으로 발사된 후 적 위에서 떨어지며 착탄 시 범위 피해를 입히는 호리병 투사체입니다.
 */

using UnityEngine;

/// <summary>
/// 수직 발사 + 적 위 낙하 + 범위 피해 투사체 클래스
/// </summary>
public class BottleProjectile : Projectile
{
    #region Private Fields
    [Header("Effect Settings")]
    [SerializeField] private GameObject _explosionEffectPrefab; // 폭발 이펙트 Prefab
    [SerializeField] private float _effectDuration = 1f; // 이펙트 지속 시간
    [SerializeField] private float _effectSizeMultiplier = 1.5f; // 이펙트 크기 배율 (폭발 반경 대비)
    
    private Vector2 _targetEnemyPosition;
    private float _explosionRadius = 2.5f;
    private bool _hasExploded = false;
    
    // 3단계 메커니즘
    private enum ProjectilePhase
    {
        Rising,      // 수직 상승
        Teleporting, // 적 위로 텔레포트
        Falling      // 낙하
    }
    
    private ProjectilePhase _currentPhase = ProjectilePhase.Rising;
    
    // 상승 단계
    private float _riseHeight = 8f; // 상승 높이
    private float _riseSpeed = 15f; // 상승 속도
    private Vector2 _startPosition;
    
    // 낙하 단계
    private float _dropHeight = 5f; // 적 위 높이
    private float _fallSpeed = 12f; // 낙하 속도 (일정하게 유지)
    
    // 회전 효과
    private float _rotationSpeed = 360f; // 초당 회전 각도 (1초에 1바퀴)
    
    private Collider2D _collider;
    #endregion

    #region Public Methods
    /// <summary>
    /// 투사체를 초기화합니다.
    /// </summary>
    /// <param name="speed">사용 안 함</param>
    /// <param name="damage">투사체 데미지</param>
    /// <param name="targetPos">목표 적 위치</param>
    /// <param name="penetration">관통 횟수 (폭발 무기이므로 사용 안 함)</param>
    /// <param name="explosionRadius">폭발 반경</param>
    public void Initialize(float speed, float damage, Vector2 targetPos, int penetration, float explosionRadius = 2.5f)
    {
        InitializeBase(speed, damage, penetration);
        _targetEnemyPosition = targetPos;
        _explosionRadius = explosionRadius;
        _hasExploded = false;
        
        _startPosition = transform.position;
        _currentPhase = ProjectilePhase.Rising;
        
        // Collider 가져오기 및 비활성화 (상승 중에는 피격 판정 없음)
        _collider = GetComponent<Collider2D>();
        if (_collider != null)
        {
            _collider.enabled = false;
        }
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// 3단계 이동 로직을 수행합니다.
    /// </summary>
    protected override void UpdateMovement()
    {
        if (_hasExploded) return;

        switch (_currentPhase)
        {
            case ProjectilePhase.Rising:
                UpdateRising();
                break;
                
            case ProjectilePhase.Teleporting:
                UpdateTeleporting();
                break;
                
            case ProjectilePhase.Falling:
                UpdateFalling();
                break;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // 낙하 단계에서만 충돌 처리
        // 적과는 충돌하지 않고, 지면/벽에만 충돌
        if (_currentPhase == ProjectilePhase.Falling && !_hasExploded)
        {
            // 적이 아닌 것(지면, 벽 등)과 충돌 시 폭발
            if (!other.CompareTag("Enemy"))
            {
                Explode();
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        // 안전 장치: 일정 시간 후 자동 파괴
        Destroy(gameObject, 10f);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// 1단계: 수직으로 상승합니다.
    /// </summary>
    private void UpdateRising()
    {
        // 수직으로 상승 (월드 공간에서 이동)
        transform.Translate(Vector2.up * _riseSpeed * Time.deltaTime, Space.World);
        
        // 회전 효과 (시각적 효과만)
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
        
        // 목표 높이에 도달하면 텔레포트 단계로
        if (transform.position.y >= _startPosition.y + _riseHeight)
        {
            _currentPhase = ProjectilePhase.Teleporting;
        }
    }

    /// <summary>
    /// 2단계: 적 위로 텔레포트합니다.
    /// </summary>
    private void UpdateTeleporting()
    {
        // 목표 적 위치의 일정 높이 위로 이동
        Vector2 dropPosition = _targetEnemyPosition + Vector2.up * _dropHeight;
        transform.position = dropPosition;
        
        // 낙하 단계로 전환
        _currentPhase = ProjectilePhase.Falling;
    }

    /// <summary>
    /// 3단계: 일정한 속도로 낙하합니다.
    /// </summary>
    private void UpdateFalling()
    {
        // 일정한 속도로 아래로 이동 (월드 공간에서 이동)
        transform.Translate(Vector2.down * _fallSpeed * Time.deltaTime, Space.World);
        
        // 회전 효과 (시각적 효과만)
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
        
        // 착지 확인 (목표 적 위치의 y좌표 근처 또는 그 아래)
        if (transform.position.y <= _targetEnemyPosition.y + 0.5f)
        {
            // 착지 시 폭발
            Explode();
        }
    }

    /// <summary>
    /// 폭발하여 범위 내 적에게 피해를 입힙니다.
    /// </summary>
    private void Explode()
    {
        if (_hasExploded) return;
        _hasExploded = true;

        // 범위 내 적 탐지 및 피해
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Monster monster = hit.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.TakeDamage(_damage);
                }
            }
        }

        // 폭발 이펙트 생성
        if (_explosionEffectPrefab != null)
        {
            GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
            
            // 이펙트 크기를 폭발 반경에 맞춰 조절
            // 기본 이펙트 크기가 1 unit이라고 가정하고, 폭발 반경의 배수로 크기 설정
            float effectScale = _explosionRadius * _effectSizeMultiplier;
            effect.transform.localScale = Vector3.one * effectScale;
            
            Destroy(effect, _effectDuration);
        }

        // 투사체 파괴
        Destroy(gameObject);
    }
    #endregion

    #region Gizmos
    private void OnDrawGizmosSelected()
    {
        // 폭발 반경 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
    #endregion
}

