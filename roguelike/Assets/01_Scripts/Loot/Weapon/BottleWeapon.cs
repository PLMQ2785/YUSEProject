/*
 * [BottleWeapon.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 범위 내 무작위 적을 향해 호리병을 수직으로 발사하는 무기입니다.
 * 호리병은 수직 상승 후 적 위에서 떨어지며 착탄 시 범위 피해를 입힙니다.
 */

using UnityEngine;

/// <summary>
/// 호리병 투척 무기 클래스 (수직 발사 방식)
/// </summary>
public class BottleWeapon : Weapon
{
    #region Serialized Fields
    [Header("Bottle Weapon Settings")]
    [SerializeField] private float _detectionRange = 15f; // 적 탐지 범위
    [SerializeField] private float _throwHeadOffset = 1.5f; // 머리 위 오프셋
    [SerializeField] private float _explosionRadius = 2.5f; // 폭발 반경
    #endregion

    #region Abstract Methods Implementation
    /// <summary>
    /// 무기 공격 로직을 수행합니다.
    /// 범위 내 무작위 적을 찾아 호리병을 투척합니다.
    /// </summary>
    protected override void PerformAttack()
    {
        // 플레이어가 초기화되지 않았으면 리턴
        if (_player == null)
        {
            return;
        }

        // 1. 범위 내 무작위 적 찾기
        Transform target = FindRandomEnemyInRange();

        Vector2 targetPosition;
        
        if (target != null)
        {
            // 적이 있으면 그 위치로
            targetPosition = target.position;
        }
        else
        {
            // 적이 없으면 플레이어가 바라보는 방향으로 일정 거리
            Vector2 direction = _player.FacingDirection;
            if (direction == Vector2.zero)
            {
                direction = Vector2.right;
            }
            targetPosition = (Vector2)_player.transform.position + direction * 5f;
        }

        // 2. 투사체 생성 (플레이어 머리 위에서 수직 발사)
        if (WeaponData == null || WeaponData.ProjectilePrefab == null)
        {
            return;
        }

        // 플레이어 위치 + 머리 위 오프셋
        Vector2 spawnPosition = (Vector2)_player.transform.position + Vector2.up * _throwHeadOffset;
        GameObject projectileObj = Instantiate(WeaponData.ProjectilePrefab, spawnPosition, Quaternion.identity);

        // 3. 투사체 초기화
        BottleProjectile projectile = projectileObj.GetComponent<BottleProjectile>();
        if (projectile != null)
        {
            projectile.Initialize(
                WeaponData.ProjectileSpeed,
                WeaponData.BaseDamage,
                targetPosition,
                WeaponData.Penetration,
                _explosionRadius
            );
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// 범위 내 무작위 적을 찾습니다.
    /// </summary>
    /// <returns>무작위로 선택된 적의 Transform, 없으면 null</returns>
    private Transform FindRandomEnemyInRange()
    {
        // 플레이어가 초기화되지 않았으면 null 반환
        if (_player == null)
        {
            return null;
        }

        // "Enemy" 태그를 가진 모든 오브젝트 찾기
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");

        if (monsters.Length == 0)
        {
            return null;
        }

        // 범위 내 적들만 필터링
        System.Collections.Generic.List<GameObject> monstersInRange = new System.Collections.Generic.List<GameObject>();

        foreach (GameObject monster in monsters)
        {
            if (monster == null || !monster.activeInHierarchy)
            {
                continue;
            }

            float distance = Vector2.Distance(_player.transform.position, monster.transform.position);

            // 탐지 범위 내의 적만 추가
            if (distance <= _detectionRange)
            {
                monstersInRange.Add(monster);
            }
        }

        // 범위 내 적이 없으면 null 반환
        if (monstersInRange.Count == 0)
        {
            return null;
        }

        // 무작위로 하나 선택
        int randomIndex = Random.Range(0, monstersInRange.Count);
        Transform randomEnemy = monstersInRange[randomIndex].transform;

        return randomEnemy;
    }
    #endregion

    #region Gizmos
    private void OnDrawGizmosSelected()
    {
        // 적 탐지 범위 표시 (플레이어 위치 기준)
        if (_player != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_player.transform.position, _detectionRange);
        }
    }
    #endregion
}
