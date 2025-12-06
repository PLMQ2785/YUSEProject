using UnityEngine;

public class EnemyReposition : MonoBehaviour
{
    const float SpawnDistance = 10f;

    const float RandomOffsetRange = 3f;


    private Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("Area"))
        {
            return;
        }

        //죽은몹
        if(!coll.enabled)
        {
            return;
        }

        Vector3 playerPos = GameManager.Instance.Player.Player_Position;

        //새로운 위치 찾기

        float RandomAngle = Random.Range(0f,360f)*Mathf.Rad2Deg;

        Vector3 spawnDir = new Vector3(Mathf.Cos(RandomAngle), Mathf.Sin(RandomAngle), 0f);

        Vector3 newSpawnPosition = playerPos + (spawnDir * SpawnDistance);

        // 4-4. 몬스터 겹침 방지를 위한 미세 랜덤 오프셋 추가
        Vector3 randomOffset = new Vector3( Random.Range(-RandomOffsetRange, RandomOffsetRange),Random.Range(-RandomOffsetRange, RandomOffsetRange),0f);

        // 5. 몬스터를 새로운 위치로 즉시 이동
        transform.position = newSpawnPosition + randomOffset;
    }

}
