/*
 * [NearestProjectile.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 가장 가까운 적을 자동으로 추적하는 투사체를 발사하는 무기입니다.
 */

using UnityEngine;

/// <summary>
/// 몬스터를 추적하는 투사체형 공격
/// </summary>
public class NearestProjectile : Weapon
{
    #region Private Fields
    [SerializeField] private float _detectionRange = 10f; // 적 탐지 범위
    #endregion
    
    #region Private Methods
    /// <summary>
    /// 가장 가까운 적을 찾습니다.
    /// </summary>
    /// <returns>가장 가까운 적의 Transform, 없으면 null</returns>
    private Transform FindNearestEnemy()
    {
        // "Enemy" 태그를 가진 모든 오브젝트 찾기
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        
        Debug.Log($"[NearestProjectile] Enemy 태그를 가진 오브젝트 수: {monsters.Length}");
        
        if (monsters.Length == 0)
        {
            return null;
        }

        Transform nearestMonster = null;
        float minDistance = float.MaxValue;
        Vector2 playerPosition = transform.position;

        int activeMonsters = 0;
        int inRangeMonsters = 0;
        
        foreach (GameObject monster in monsters)
        {
            // 비활성화된 몬스터는 제외
            if (!monster.activeInHierarchy)
            {
                continue;
            }

            activeMonsters++;
            float distance = Vector2.Distance(playerPosition, monster.transform.position);
            
            // 탐지 범위 밖의 적은 제외
            if (distance > _detectionRange)
            {
                continue;
            }
            
            inRangeMonsters++;
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestMonster = monster.transform;
            }
        }

        Debug.Log($"[NearestProjectile] 활성화된 몬스터: {activeMonsters}, 범위 내: {inRangeMonsters}, 가장 가까운 거리: {(nearestMonster != null ? minDistance.ToString("F2") : "없음")}");
        return nearestMonster;
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// 무기 공격 로직을 수행합니다.
    /// 가장 가까운 적을 찾아 추적 투사체를 발사합니다.
    /// </summary>
    protected override void PerformAttack()
    {
        Debug.Log("[NearestProjectile] PerformAttack 호출됨");
        
        // 1. 가장 가까운 적 찾기
        Transform target = FindNearestEnemy();
        
        if (target == null)
        {
            // 적이 없으면 발사하지 않음
            Debug.Log("[NearestProjectile] 타겟을 찾지 못했습니다.");
            return;
        }

        Debug.Log($"[NearestProjectile] 타겟 발견: {target.name}");

        // 2. 투사체 생성
        if (WeaponData == null)
        {   
            Debug.LogError("[NearestProjectile] WeaponData가 null입니다!");
            return;
        }
        
        if (WeaponData.ProjectilePrefab == null)
        {
            Debug.LogError("[NearestProjectile] WeaponData.ProjectilePrefab이 null입니다!");
            return;
        }

        Debug.Log($"[NearestProjectile] 투사체 생성 중... Prefab: {WeaponData.ProjectilePrefab.name}");
        
        // 플레이어 위치에서 생성
        GameObject projectileObj = Instantiate(WeaponData.ProjectilePrefab, transform.position, Quaternion.identity);
        
        Debug.Log($"[NearestProjectile] 투사체 생성됨: {projectileObj.name}");
        
        // 3. 투사체 초기화
        HomingProjectile projectile = projectileObj.GetComponent<HomingProjectile>();
        if (projectile != null)
        {
            Debug.Log("[NearestProjectile] HomingProjectile 컴포넌트 찾음, 초기화 중...");
            
            // 플레이어 스탯을 반영한 최종 데미지 계산
            float finalDamage = CalculateDamage(WeaponData.BaseDamage, out bool isCritical);
            
            projectile.Initialize(
                WeaponData.ProjectileSpeed,
                finalDamage,
                target,
                WeaponData.Penetration
            );
            Debug.Log("[NearestProjectile] 투사체 초기화 완료!");
        }
        else
        {
            Debug.LogError("[NearestProjectile] HomingProjectile 컴포넌트를 찾을 수 없습니다!");
        }
    }
    #endregion
}

