using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("References")]
    [SerializeField] private Transform playerTransform; 
    // [삭제] poolContainer는 이제 PoolManager가 관리하므로 필요 없음

    [Header("Wave Settings")] 
    [SerializeField] private List<WaveData> waves;
    [SerializeField] private BossMonster firstBossPrefab;  // 5분(300초) 보스
    [SerializeField] private BossMonster secondBossPrefab; // 10분(600초) 최종 보스

    [Header("Spawn Settings")] 
    [SerializeField] private float spawnRadius = 10.0f;
    [SerializeField] private int initialPerTypeSize = 10;
    #endregion

    #region Events
    public event Action<bool,BossMonster> OnBossSpawned;
    #endregion

    #region Private Fields
    private WaveData _currentWave;
    private bool _isBossActive;
    private bool _isSecondBossActive = false; // 현재 활성화된 보스가 두 번째 보스인지
    
    // 각 보스의 스폰 여부 추적
    private bool _firstBossSpawned = false;
    private bool _secondBossSpawned = false;

    // 현재 필드 몬스터 리스트 (마릿수 제한용)
    private List<Monster> _activeMonsters = new List<Monster>();
    
    // 각 MonsterSpawnInfo마다 독립적인 타이머
    private Dictionary<MonsterSpawnInfo, float> _spawnTimers = new Dictionary<MonsterSpawnInfo, float>();
    #endregion

    #region Unity LifeCycle
    private void Start()
    {
        if (waves == null || waves.Count == 0)
        {
            Debug.LogWarning("SpawnManager: WaveData가 비어있습니다!");
        }
        
        PreloadAllWaveMonsters();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing) return;
        if (_isBossActive) return;

        float currentGameTime = GameManager.Instance.GameTime;

        // 1. 보스 스폰 체크
        // 첫 번째 보스: 5분(300초)
        if (currentGameTime >= 300f && !_firstBossSpawned)
        {
            SpawnBoss(firstBossPrefab, false);
            _firstBossSpawned = true;
            return;
        }
        
        // 두 번째 보스 (최종 보스): 10분(600초)
        if (currentGameTime >= 600f && !_secondBossSpawned)
        {
            SpawnBoss(secondBossPrefab, true);
            _secondBossSpawned = true;
            return;
        }

        // 2. 웨이브 데이터 갱신
        UpdateWaveData(currentGameTime);

        // 3. 몬스터 스폰
        if (_currentWave != null)
        {
            ProcessWaveSpawning();
        }
    }
    #endregion

    #region Wave & Boss Logic
    
    private void UpdateWaveData(float time)
    {
        WaveData previousWave = _currentWave;
        
        if (_currentWave != null && time >= _currentWave.startTime && time < _currentWave.endTime) return;
        
        foreach (var wave in waves)
        {
            if (time >= wave.startTime && time < wave.endTime)
            {
                _currentWave = wave;
                
                // 웨이브가 변경되었으면 타이머 초기화
                if (_currentWave != previousWave)
                {
                    _spawnTimers.Clear();
                }
                return;
            }
        }
    }

    private void ProcessWaveSpawning()
    {
        // 각 MonsterSpawnInfo마다 독립적으로 처리
        foreach (var spawnInfo in _currentWave.monsterSpawnInfos)
        {
            if (spawnInfo == null || spawnInfo.monsterPrefab == null)
                continue;
                
            // 해당 몬스터의 타이머 가져오기 (없으면 0으로 초기화)
            if (!_spawnTimers.ContainsKey(spawnInfo))
            {
                _spawnTimers[spawnInfo] = 0f;
            }
            
            // 타이머 증가
            _spawnTimers[spawnInfo] += Time.deltaTime;
            
            // 스폰 간격이 되었는지 체크
            if (_spawnTimers[spawnInfo] >= spawnInfo.spawnInterval)
            {
                // spawnCount만큼 스폰 시도
                for (int i = 0; i < spawnInfo.spawnCount; i++)
                {
                    // 필드 제한 체크
                    if (_activeMonsters.Count >= _currentWave.maxFieldMonsterCount)
                        break;
                    
                    Vector2 pos = CalculateSpawnPosition();
                    SpawnMonster(spawnInfo.monsterPrefab, pos);
                }
                
                // 타이머 리셋
                _spawnTimers[spawnInfo] = 0f;
            }
        }
    }

    private void SpawnBoss(BossMonster bossPrefab, bool isSecondBoss)
    {
        _isBossActive = true;
        _isSecondBossActive = isSecondBoss;
        GameManager.Instance.IsTimerStopped = true;

        Vector2 spawnPos = CalculateSpawnPosition();
        BossMonster boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        boss.Init(playerTransform, BossDied);

        string bossType = isSecondBoss ? "FINAL BOSS" : "BOSS";
        Debug.Log($"{bossType} APPEARED!");
        OnBossSpawned?.Invoke(_isBossActive, boss); // 보스 출현 방송
    }

    private void BossDied(Monster boss)
    {
        Debug.Log("BOSS DEFEATED!");
        _isBossActive = false;
        GameManager.Instance.IsTimerStopped = false;
        
        // 두 번째 보스(최종 보스)를 처치했으면 게임 클리어
        if (_isSecondBossActive)
        {
            Debug.Log("FINAL BOSS DEFEATED! GAME CLEAR!");
            GameManager.Instance.GameClear();
        }
        
        _isSecondBossActive = false;
        Destroy(boss.gameObject);
        OnBossSpawned?.Invoke(_isBossActive, (BossMonster)boss); // 보스 처치 방송
    }
    #endregion

    #region Object Pooling Logic (Delegated to PoolManager)
    
    public void SpawnMonster(Monster prefab, Vector2 position)
    {
        // 1. PoolManager에게 GameObject 요청
        GameObject obj = PoolManager.Instance.Get(prefab.gameObject, position, Quaternion.identity);
        
        // 2. Monster 컴포넌트 가져오기
        Monster monster = obj.GetComponent<Monster>();

        // 3. 초기화 (콜백에서 prefab 정보를 캡처해서 넘겨줌)
        monster.Init(playerTransform, (m) => ReturnToPool(m, prefab));

        // 4. 활성 리스트에 추가
        _activeMonsters.Add(monster);
    }

    public void ReturnToPool(Monster monster, Monster prefab)
    {
        // 1. 활성 리스트에서 제거
        _activeMonsters.Remove(monster);
        
        // 2. PoolManager에게 반환 요청
        PoolManager.Instance.ReturnToPool(monster.gameObject, prefab.gameObject);
    }
    
    private void PreloadAllWaveMonsters()
    {
        // 중복 방지 (Instance ID 사용)
        HashSet<int> processedIDs = new HashSet<int>();

        foreach (var wave in waves)
        {
            // 1. waveData 객체 자체가 null인지 확인합니다.
            if (wave == null)
            {
                Debug.LogWarning("SpawnManager: Waves 리스트에 할당되지 않은 빈 슬롯(Null)이 있습니다. 건너뜁니다.");
                continue;
            }
                
            // 2. monsterSpawnInfos 리스트 자체가 null인지 확인합니다.
            if (wave.monsterSpawnInfos == null)
            {
                Debug.LogWarning($"SpawnManager: '{wave.name}' WaveData의 monsterSpawnInfos 리스트가 Null입니다. 인스펙터에서 초기화하거나 몬스터를 할당해주세요. 건너뜁니다.");
                continue;
            }
            
            foreach (var spawnInfo in wave.monsterSpawnInfos)
            {
                if (spawnInfo == null || spawnInfo.monsterPrefab == null)
                {
                    continue;
                }
                
                int id = spawnInfo.monsterPrefab.gameObject.GetInstanceID();
                if (processedIDs.Contains(id)) continue; 

                // PoolManager에게 미리 생성 요청
                PoolManager.Instance.Preload(spawnInfo.monsterPrefab.gameObject, initialPerTypeSize);
                
                processedIDs.Add(id);
            }
        }
    }
    
    public Vector2 CalculateSpawnPosition()
    {
        Vector2 randomDir = UnityEngine.Random.insideUnitCircle.normalized;
        Vector2 origin = playerTransform != null ? (Vector2)playerTransform.position : Vector2.zero;
        return origin + (randomDir * spawnRadius);
    }
    #endregion
}