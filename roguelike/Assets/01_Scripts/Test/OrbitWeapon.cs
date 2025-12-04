using System.Collections.Generic;
using UnityEngine;

public class OrbitWeapon :Weapon
{

    [Header("Setting")]
    [SerializeField] private int _projectileCount = 4;
    [SerializeField] private float _orbitRadius = 2.5f;
    [SerializeField] private float _rotationSpeed = 100f;

    //리스트안에다가 돌아가는 총알 넣어놓기
    private List<GameObject> _spawnProjectile = new List<GameObject>();
    private float _currentAngle = 0f;


    private void Start()
    {
        SpawnProjectile();
    }


    protected override void Update()
    {
        //각도를 업데이트해줘서 돌아가게 해줘야함
        _currentAngle += _rotationSpeed * Time.deltaTime;

        RotateProjectile();
    }

    private void SpawnProjectile()
    {
        for(int i=0; i< _projectileCount; i++)
        {
            GameObject orbit = Instantiate(WeaponData.ProjectilePrefab,transform.position, Quaternion.identity,transform);
            OrbitProjectile projectile = orbit.GetComponent<OrbitProjectile>();

            projectile.initialize(WeaponData.BaseDamage);
            _spawnProjectile.Add(orbit);
        }

        RotateProjectile();
    }

    private void RotateProjectile()
    {
        if(_spawnProjectile.Count==0) return;

        float angle_Interval = 360f / _spawnProjectile.Count;

        for(int i=0;i< _spawnProjectile.Count;i++)
        {
            float finalAngle = _currentAngle + (angle_Interval * i);

             //Deg2Rad는 각도를 라디안으로 변환
            float rad = finalAngle * Mathf.Deg2Rad;
            float x = Mathf.Cos(rad) * _orbitRadius;
            float y = Mathf.Sin(rad) * _orbitRadius;

            // 플레이어(Weapon) 위치를 기준으로 오프셋 적용
            Vector3 offset = new Vector3(x, y, 0);

            // 리스트에 있는 총알의 위치를 강제로 이동
            if (_spawnProjectile[i] != null)
            {
                _spawnProjectile[i].transform.position = transform.position + offset;

                //칼날 바깥으로 위치하게 하는 로직
                Vector3 direction = _spawnProjectile[i].transform.position-transform.position;
                //방향 벡터를 각도로 변환하는 것
                float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
                //칼날이 바깥쪽으로 향하게 
                _spawnProjectile[i].transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            }
        }
    }




    protected override void PerformAttack()
    {
        
    }
}
