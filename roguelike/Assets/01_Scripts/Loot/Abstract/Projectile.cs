/*
 * [Projectile.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 무기에서 발사되는 투사체의 추상 베이스 클래스입니다.
 * 공통 로직(충돌 처리, 데미지, 관통)을 정의하며, 이동 로직은 각 구현체에서 정의합니다.
 */

using UnityEngine;

/// <summary>
/// 무기 투사체 추상 베이스 클래스
/// </summary>
public abstract class Projectile : MonoBehaviour
{
    #region Protected Fields
    protected float _speed;
    protected float _damage;
    protected int _penetration;
    #endregion

    #region Unity LifeCycle
    protected virtual void Update()
    {
        UpdateMovement();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(_damage);
                _penetration--;

                if (_penetration <= 0)
                {
                    Destroy(gameObject);
                    // TODO: 파괴 대신 풀로 들어가도록?
                }
            }
        }
        else if (other.CompareTag("Wall")) // 벽에 부딪히면 파괴
        {
            Destroy(gameObject);
            // TODO: 파괴 대신 풀로 들어가도록?
        }
    }

    protected virtual void Start()
    {
        // 일정 시간 후 자동 파괴 (안전 장치)
        Destroy(gameObject, 5f);
        // TODO: 파괴 대신 풀로 들어가도록?
    }
    #endregion

    #region Abstract Methods
    /// <summary>
    /// 투사체의 이동 로직을 구현합니다.
    /// 각 투사체 타입(직선, 추적 등)에서 오버라이드하여 구현합니다.
    /// </summary>
    protected abstract void UpdateMovement();
    #endregion

    #region Protected Methods
    /// <summary>
    /// 투사체의 기본 속성을 초기화합니다.
    /// </summary>
    /// <param name="speed">투사체 속도</param>
    /// <param name="damage">투사체 데미지</param>
    /// <param name="penetration">관통 횟수</param>
    protected void InitializeBase(float speed, float damage, int penetration)
    {
        _speed = speed;
        _damage = damage;
        _penetration = penetration;
    }
    #endregion
}
