using UnityEngine;

/// <summary>
/// 몬스터별 스폰 정보를 담는 클래스
/// 각 몬스터마다 독립적인 스폰 간격과 개수를 설정할 수 있습니다.
/// </summary>
[System.Serializable]
public class MonsterSpawnInfo
{
    [Header("Monster Settings")]
    [Tooltip("스폰할 몬스터 프리팹")]
    public Monster monsterPrefab;
    
    [Header("Spawn Settings")]
    [Tooltip("이 몬스터의 스폰 간격 (초)")]
    public float spawnInterval = 5f;
    
    [Tooltip("한 번에 스폰할 개수")]
    [Min(1)]
    public int spawnCount = 1;
}
