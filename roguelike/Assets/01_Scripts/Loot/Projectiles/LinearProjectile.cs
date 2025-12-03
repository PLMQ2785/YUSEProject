/*
 * [LinearProjectile.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 직선으로 날아가는 투사체입니다.
 */

using UnityEngine;

/// <summary>
/// 직선 이동 투사체 클래스
/// </summary>
public class LinearProjectile : Projectile
{
    #region Private Fields
    private Vector2 _direction;
    #endregion

    #region Public Methods
    /// <summary>
    /// 투사체를 초기화합니다.
    /// </summary>
    /// <param name="speed">투사체 속도</param>
    /// <param name="damage">투사체 데미지</param>
    /// <param name="direction">발사 방향</param>
    /// <param name="penetration">관통 횟수</param>
    public void Initialize(float speed, float damage, Vector2 direction, int penetration)
    {
        InitializeBase(speed, damage, penetration);
        _direction = direction.normalized;
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// 직선 이동 로직을 수행합니다.
    /// </summary>
    protected override void UpdateMovement()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }
    #endregion
}
