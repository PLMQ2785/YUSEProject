using UnityEngine;

public class BasicWeapon :Weapon
{
    [Header("setting")]

   
    [SerializeField] private float attackRange =2.0f;
    [SerializeField] private float duration = 5f;
    


    
    protected override void PerformAttack()
    {
        // 1. 방향 및 위치 계산
        if (WeaponData.ProjectilePrefab == null)
            return;

        Vector2 facingDir = _player.FacingDirection;

        
        if (facingDir == Vector2.zero)
            facingDir = Vector2.left;

        Vector3 spawnPos = transform.position + (Vector3)(facingDir.normalized * attackRange);

        // 3. 회전 계산 )
   
        float angle = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // 4. 생성 (플레이어를 부모로 설정)
        GameObject slashObj = Instantiate(WeaponData.ProjectilePrefab, spawnPos, rotation);

        SlashProjectile slash = slashObj.GetComponent<SlashProjectile>();
        slash.Initialize(WeaponData.BaseDamage, duration); 
    
    }
}
