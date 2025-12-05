using System.Collections.Generic;
using UnityEngine;

public class Lightning : Weapon
{
    #region private 변수
    [Header("설정")]
    [SerializeField] private GameObject _lightningEffectPrefab;
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _damageRange = 1.5f;
    [SerializeField] private int _strikeCount = 3;

    //적 레이어 미리 저장
    [SerializeField] private LayerMask _targetLayer; 

    private List<Collider2D> _targets = new List<Collider2D>();
    private ContactFilter2D _contactFilter;

    #endregion


    #region life Cycle
    private void Start()
    {
        _contactFilter.useTriggers = true;
        _contactFilter.SetLayerMask(_targetLayer);
        _contactFilter.useLayerMask = true;
    }
    #endregion

    protected override void PerformAttack()
    {
        //플레이어 자식으로 들어갈꺼니까
       Vector3 playerPos= transform.position;

        // 플레이어 스탯을 반영한 최종 데미지 계산 (번개는 한번만 계산)
        float finalDamage = CalculateDamage(WeaponData.BaseDamage, out bool isCritical);

       for(int i=0;i<_strikeCount;i++)
        {
            Vector2 ran_pos = Random.insideUnitCircle * _attackRange;
            Vector3 targetPos = playerPos + new Vector3(ran_pos.x, ran_pos.y, 0);

            int count =Physics2D.OverlapCircle(targetPos, _damageRange, _contactFilter,_targets);

            if (count>0)
            {
                foreach(var col  in _targets)
                {
                    Debug.Log("적감지");
                    Monster enemy = col.GetComponent<Monster>();
                    
                    if(enemy != null)
                    {
                        enemy.TakeDamage(finalDamage);
                    }
                }
            }

            if(_lightningEffectPrefab != null)
            {
                GameObject effect = Instantiate(_lightningEffectPrefab,targetPos,Quaternion.identity);

                effect.transform.localScale = Vector3.one * _damageRange * 1.5f;
                Destroy(effect,0.5f);
            }
           
        }
    }
}
