using UnityEngine;
// using static UnityEditor.Experimental.GraphView.GraphView;

public class ShotgunWeapon :Weapon
{



    private void Start()
    {
        if (_player==null)
        {
            _player = GetComponentInParent<PlayerManager>();
        }
        
    }
    protected override void PerformAttack()
    {
       
        if (WeaponData == null)
        {
            
            return;
        }

        if (WeaponData.ProjectilePrefab == null)
        {
            
            return;
        }
        Vector3 fireDirection = GetFireDirection();
        Debug.Log($"2. 발사 방향: {fireDirection}");

        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Vector3 spawnPos = transform.position;

      
        GameObject projectile = Instantiate(WeaponData.ProjectilePrefab, spawnPos, rotation);
        Debug.Log($"3. 총알 생성됨: {projectile.name}, 위치: {spawnPos}");



        ClusterProjectile cluster = projectile.GetComponent<ClusterProjectile>();

        if (cluster == null)
        {
            Debug.LogError("오류 발생! 생성된 총알에 'ClusterProjectile' 스크립트가 없습니다!");
            Debug.LogError($"생성된 오브젝트 이름: {projectile.name}");
            // 스크립트가 없으면 아래 initialize를 실행하면 안되므로 리턴
            return;
        }
        else
        {
            Debug.Log("스크립트 찾음. 초기화 진행.");
            cluster.initialize(WeaponData.BaseDamage, WeaponData.ProjectileSpeed);
        }
        
      
    }


    private Vector3 GetFireDirection()
    {
        // 부모 클래스(EquipmentBase)가 _player를 이미 찾아놨다고 가정
        if (_player != null)
        {
            // PlayerManager에 이미 있는 FacingDirection을 그대로 사용!
            return _player.FacingDirection;
        }

        // 혹시나 플레이어를 못 찾았을 때를 대비한 기본값
        return Vector3.right;
    }
}





