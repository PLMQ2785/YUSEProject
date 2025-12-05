using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    [Header("Wave Time Settings")]
    [Tooltip("웨이브 시작 시간 (초)")]
    public float startTime;

    [Tooltip("웨이브 종료 시간 (초)")]
    public float endTime;

    [Header("Spawn Settings")]
    [Tooltip("몬스터 생성 간격 (초)")]
    public float spawnInterval = 2.0f;

    [Tooltip("화면에 유지될 최대 몬스터 수")]
    public int maxFieldMonsterCount = 30;

    [Header("Monsters")]
    [Tooltip("등장할 몬스터 스폰 정보 목록 (각 몬스터마다 독립적인 스폰 설정)")]
    public List<MonsterSpawnInfo> monsterSpawnInfos;
}
