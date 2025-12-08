using System.Runtime.InteropServices;
using UnityEngine;

public class ClusterProjectile : Projectile
{
    [Header("Setting")]

    [SerializeField] private GameObject _splitProjectilePrefab;
    [SerializeField] private GameObject _explosionEffectPrefab;
    [SerializeField] private int _splitCount=3;
    [SerializeField] private float _splitSpeed=8f;
    [SerializeField] private float _splitDamage = 0.7f;

    [Header("터지는 시간 설정")]
    [SerializeField] private float _explodeTime = 1.5f;
    private float _timer = 0f;


    public void initialize(float damage, float speed)
    {
        _damage = damage;
        _speed = speed;
    }


    protected override void Update()
    {
        
        base.Update();
        _timer += Time.deltaTime;
        if(_timer>=_explodeTime)
        {

            Explode();
            Destroy(gameObject);
        }
    }


    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Monster monster = other.GetComponent<Monster>();

            monster.TakeDamage(_damage);

            Explode();
            Destroy(gameObject);
        }
    }

    protected override void UpdateMovement()
    {
        //Debug.Log("움직임");
        transform.position += transform.right * _speed * Time.deltaTime;
    }



    private void Explode()
    {
        if (_splitProjectilePrefab == null) return;

        // 폭발 이펙트 생성
        if (_explosionEffectPrefab != null)
        {
            GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect,1.0f);
        }

        // ★ 1. 현재 날아가던 총알의 각도를 가져옵니다. (이게 기준점이 됩니다)
        float baseAngle = transform.eulerAngles.z;

        // 2. 부채꼴 모양 설정을 위한 변수
        float totalSpreadAngle = 60f; // 전체 부채꼴 각도 (예: 60도 범위로 퍼짐)

        // 시작 각도 계산: (중앙 각도) - (절반 범위)
        // 예: 날아가던 방향이 90도고 퍼짐이 60도면, 60도(90-30)부터 시작
        float startAngle = baseAngle - (totalSpreadAngle / 2f);

        // 각 총알 사이의 간격 각도
        // 총알이 1발이면 간격은 0, 2발 이상이면 (전체각도 / (개수-1))
        float angleStep = (_splitCount > 1) ? (totalSpreadAngle / (_splitCount - 1)) : 0f;

        for (int i = 0; i < _splitCount; i++)
        {
            // 3. 각 총알의 최종 각도 계산
            // 만약 총알이 1발이면 그냥 정면(baseAngle)으로 나감
            float currentAngle = (_splitCount > 1) ? startAngle + (angleStep * i) : baseAngle;

            // 회전값 생성
            Quaternion rotateAngle = Quaternion.Euler(0, 0, currentAngle);

            // 생성
            GameObject split = Instantiate(_splitProjectilePrefab, transform.position, rotateAngle);

            // 초기화
            SplitProjectile projectile = split.GetComponent<SplitProjectile>();
            if (projectile != null)
            {
                projectile.initialize(_damage * _splitDamage, _splitSpeed);
            }
        }
    }


}
