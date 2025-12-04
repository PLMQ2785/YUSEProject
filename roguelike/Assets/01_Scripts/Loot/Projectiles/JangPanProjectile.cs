using System.Collections;
using UnityEngine;

public class JangPanProjectile : Projectile
{
    #region private 변수
    [Header("setting")]

    private float duration = 5f;
    private float damagePerTick;
    private Collider2D myCollider;
    #endregion

    #region public 함수
    public void Initialize(float speed, float damage, int penetration)
    {
        _speed = speed;
        _damage = damage;
        _penetration = penetration;
    }

    #endregion

    #region protect 함수

    protected override void Start()
    {
        myCollider = GetComponent<Collider2D>();
        if (duration > 0)
            damagePerTick = _damage / duration;
        else
            damagePerTick = _damage;

        Destroy(gameObject,duration);
    }

    protected override void UpdateMovement()
    {
        //움직일 필요가없음
    }
   
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Enemy"))
        {
           StartCoroutine(DamageRoutine(other));
        }
    }
    #endregion

    #region 코루틴
    //데미지 주는 로직

    IEnumerator DamageRoutine(Collider2D target)
    {
        Monster monster = target.GetComponent<Monster>();


        //몬스터가 있고 총알이랑 몬스터의 콜라이더가 계속 접촉중일 경우
        while(monster != null && myCollider.IsTouching(target))
        {
            monster.TakeDamage(damagePerTick);

            yield return new WaitForSeconds(0.5f);
        }

    }
    #endregion
}
