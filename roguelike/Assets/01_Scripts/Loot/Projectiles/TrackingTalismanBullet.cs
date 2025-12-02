/*
 * [HomingProjectile.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 타겟을 추적하는 투사체입니다.
 */

using UnityEngine;

/// <summary>
/// 타겟 추적 투사체 클래스
/// </summary>
public class HomingProjectile : Projectile
{
    #region Private Fields
    private Transform _target;
    private Vector2 _currentDirection;
    private float _rotationSpeed = 360f; // 초당 회전 각도 (높을수록 빠르게 회전)
    
    // 초기 사출 효과
    private float _baseSpeed; // 원래 속도
    private float _currentSpeedMultiplier = 2.5f; // 초기 속도 배율 (2.5배)
    private float _speedDecayRate = 3f; // 속도 감소율 (초당)
    #endregion

    #region Public Methods
    /// <summary>
    /// 투사체를 초기화합니다.
    /// </summary>
    /// <param name="speed">투사체 속도</param>
    /// <param name="damage">투사체 데미지</param>
    /// <param name="target">추적할 타겟</param>
    /// <param name="penetration">관통 횟수</param>
    public void Initialize(float speed, float damage, Transform target, int penetration)
    {
        InitializeBase(speed, damage, penetration);
        _target = target;
        _baseSpeed = speed; // 원래 속도 저장
        _currentSpeedMultiplier = 2.5f; // 초기 사출 효과 리셋
        
        // 적 방향의 수직(90도)으로 발사하여 큰 원호를 그리며 날아가도록 함
        if (_target != null)
        {
            Vector2 toTarget = ((Vector2)_target.position - (Vector2)transform.position).normalized;
            
            // 타겟 방향의 수직 방향 (90도 또는 -90도) + 약간의 랜덤성
            // 랜덤하게 왼쪽이나 오른쪽으로 튀어나가게 함
            float perpendicularAngle = Random.value > 0.5f ? 90f : -90f;
            perpendicularAngle += Random.Range(-20f, 20f); // 70~110도 또는 -110~-70도 범위
            
            _currentDirection = Rotate(toTarget, perpendicularAngle);
        }
        else
        {
            // 무작위 방향으로 시작
            float randomAngle = Random.Range(0f, 360f);
            _currentDirection = Rotate(Vector2.right, randomAngle);
        }
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// 타겟 추적 이동 로직을 수행합니다.
    /// 타겟이 없으면 현재 방향으로 직진합니다.
    /// </summary>
    protected override void UpdateMovement()
    {
        // 속도 배율 감소 (시간이 지남에 따라 1.0으로 수렴)
        if (_currentSpeedMultiplier > 1f)
        {
            _currentSpeedMultiplier -= _speedDecayRate * Time.deltaTime;
            if (_currentSpeedMultiplier < 1f)
            {
                _currentSpeedMultiplier = 1f;
            }
        }
        
        // 타겟이 유효하면 추적
        if (_target != null && _target.gameObject.activeInHierarchy)
        {
            Vector2 targetPosition = _target.position;
            Vector2 currentPosition = transform.position;
            Vector2 toTarget = (targetPosition - currentPosition).normalized;

            // 현재 방향과 목표 방향의 각도 계산
            float currentAngle = Mathf.Atan2(_currentDirection.y, _currentDirection.x) * Mathf.Rad2Deg;
            float targetAngle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;

            // 현재 각도에서 목표 각도로 부드럽게 회전
            float maxRotation = _rotationSpeed * Time.deltaTime;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, maxRotation);

            // 각도를 방향 벡터로 변환
            float radians = newAngle * Mathf.Deg2Rad;
            _currentDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        }
        // 타겟이 없으면 현재 방향으로 직진

        // 스프라이트를 이동 방향으로 회전 (부적이 날아가는 방향을 향하도록)
        float angle = Mathf.Atan2(_currentDirection.y, _currentDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // -90도는 스프라이트가 위를 향하고 있다고 가정

        // 이동 (초기 속도 부스트 적용)
        float currentSpeed = _baseSpeed * _currentSpeedMultiplier;
        transform.Translate(_currentDirection * (currentSpeed * Time.deltaTime), Space.World);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// 벡터를 특정 각도만큼 회전시킵니다.
    /// </summary>
    private Vector2 Rotate(Vector2 vector, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);
        return new Vector2(
            vector.x * cos - vector.y * sin,
            vector.x * sin + vector.y * cos
        );
    }
    #endregion
}
