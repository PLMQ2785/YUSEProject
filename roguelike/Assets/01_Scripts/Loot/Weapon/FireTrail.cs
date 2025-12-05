using UnityEngine;

public class Fire_Trail :Weapon
{

    #region private 변수
    [Header("속성")]
    [SerializeField] private float _spawnDistance = 1f;
    private Vector3 _lastSpawnPos;
    #endregion


    
    protected override void PerformAttack()
    {
        if (WeaponData == null || WeaponData.ProjectilePrefab == null)
        {
            Debug.LogWarning("WeaponData 또는 ProjectilePrefab이 비어있음");
            return;
        }

        // 중첩해서 깔리는 문제 해결

        if (Vector3.Distance(transform.position, _lastSpawnPos) < _spawnDistance)
        {

            Debug.Log("거리가 너무가깝게 스폰됨");
            return;
        }

        GameObject fireTrail =Instantiate(WeaponData.ProjectilePrefab,transform.position,Quaternion.identity);

        JangPanProjectile projectile =  fireTrail.GetComponent<JangPanProjectile>();

        //계속 지속되야하니 관통력 높게 설정
        if (projectile != null)
        {
            projectile.Initialize(0, WeaponData.BaseDamage, 9999);
        }

        _lastSpawnPos = transform.position;
    }
}
