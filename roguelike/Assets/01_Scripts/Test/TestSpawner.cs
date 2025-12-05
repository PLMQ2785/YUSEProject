using System.Collections.Generic;
using UnityEngine;

public class TemporaryMonsterSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    
    [Header("Prefabs")]
    [SerializeField] private List<Monster> monsterPrefabs;
    [SerializeField] private List<BossMonster> bossPrefabs;

    private void Update()
    {
        // 숫자 키 4~9로 일반 몬스터 스폰
        for (int i = 0; i < monsterPrefabs.Count; i++)
        {
            if (i >= 9) break; 
            if (Input.GetKeyDown(KeyCode.Alpha1 + i + 3))
            {
                SpawnMonster(monsterPrefabs[i]);
            }
        }

        // B 키로 첫 번째 보스 스폰
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (bossPrefabs != null && bossPrefabs.Count > 0)
            {
                SpawnBoss(bossPrefabs[0]); 
            }
        }
    }

    private void SpawnMonster(Monster prefab)
    {
        if (prefab == null) return;

        Vector2 spawnPos = GetMouseWorldPosition();
        // 임시 스폰이므로 풀링을 사용하지 않고 직접 Instantiate
        Monster monster = Instantiate(prefab, spawnPos, Quaternion.identity);
        
        // 몬스터 초기화 (타겟 설정)
        // 임시 스폰이므로 풀 반환 콜백은 null 혹은 Destroy 로직으로 처리되도록 함
        monster.Init(playerTransform, null); 
    }

    private void SpawnBoss(BossMonster prefab)
    {
        if (prefab == null) return;

        Vector2 spawnPos = GetMouseWorldPosition();
        BossMonster boss = Instantiate(prefab, spawnPos, Quaternion.identity);
        boss.Init(playerTransform, null);
        
        Debug.Log($"[TempSpawner] Boss Spawned at {spawnPos}");
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        // 2D 게임이므로 Z축 처리가 중요할 수 있음. 메인 카메라 기준으로 변환.
        if (Camera.main != null)
        {
            mousePos.z = -Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
        return Vector2.zero;
    }
}