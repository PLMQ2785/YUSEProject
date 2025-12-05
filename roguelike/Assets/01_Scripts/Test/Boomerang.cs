using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Boomerang : Weapon
{
    [Header("설정 값")]

    [SerializeField] private float _flyDistance = 5f;
    [SerializeField] private float _flySpeed = 10f;
    [SerializeField] private float _rotateSpeed = 720f;
    [SerializeField] private float _returnAcceleration = 20f; //돌아올때 가속
    //날라가고 있는지 확인하기
    private bool _isAttack = false;
    private Transform _parent;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if( _spriteRenderer != null )
            _spriteRenderer.enabled = false;
    }


    protected override void PerformAttack()
    {

        //날라가고 있으면 실행 x
        if (_isAttack)
            return;

        StartCoroutine(AttackRoutine());
    }


    private IEnumerator AttackRoutine()
    {
        _isAttack = true;

        _parent = transform.parent;
        transform.parent = null;   
      
        //시작 지점은 부모 기준
        Vector3 startPos = Vector3.zero;
        //랜덤 방향으로 발사
        Vector3 direction = Random.insideUnitCircle.normalized;
        //도착 위치
        Vector3 targetPos = direction * _flyDistance;

        //날아갈땐 보이게하기
        if (_spriteRenderer != null)
            _spriteRenderer.enabled= true;

        
        //거리가 0.1보다 클태까지 날라가고
        while (Vector3.Distance(transform.position,targetPos)>0.1f)
        {
          

            //목표 지점으로
            transform.position = Vector3.MoveTowards(transform.position,targetPos, _flySpeed*Time.deltaTime);

            //회전
            transform.Rotate(0,0,-_rotateSpeed*Time.deltaTime);

            yield return null;
        }

        //가서 살짝 멈췄다가
        yield return new WaitForSeconds(0.2f);
        float currentAcceleration = 0f;

        while (Vector3.Distance(transform.position,_parent.position)>0.1f)
        {
            currentAcceleration += _returnAcceleration * Time.deltaTime;
            transform.position= Vector3.MoveTowards(transform.position, _parent.position, currentAcceleration * Time.deltaTime);


            transform.Rotate(0, 0, -_rotateSpeed * Time.deltaTime);

            yield return null;
        }

        transform.parent=_parent;
        transform.localPosition = Vector3.zero;
        transform.rotation= Quaternion.identity;
        //다시 들어오면 끄기
        if (_spriteRenderer != null)
            _spriteRenderer.enabled = false;
        _isAttack =false;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (_isAttack && collision.CompareTag("Enemy"))
        {
           
            Monster enemy = collision.GetComponent<Monster>();

            if(enemy != null)
            {
                // 플레이어 스탯을 반영한 최종 데미지 계산
                float finalDamage = CalculateDamage(WeaponData.BaseDamage, out bool isCritical);
                enemy.TakeDamage(finalDamage);
            }
        }

    }
}

    

