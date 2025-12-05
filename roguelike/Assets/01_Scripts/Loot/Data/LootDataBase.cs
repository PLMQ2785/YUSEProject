using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootDataBase : MonoBehaviour
{
    #region Singleton
    private static LootDataBase _instance;
    public static LootDataBase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LootDataBase>();
                if (_instance == null)
                {
                    Debug.LogError("LootDataBase instance not found in scene!");
                }
            }
            return _instance;
        }
    }
    #endregion

    #region Serialized Fields
    [Header("Monster Pool")]
    [SerializeField] private List<Monster> monsterPool;

    [Header("Equipment Pool")]
    [SerializeField] private List<EquipmentData> weaponPool;
    [SerializeField] private List<EquipmentData> passivePool;

    [Header("Item Pool")]
    [SerializeField] private List<ItemData> itemPool;
    #endregion

    #region Private Fields
    // 런타임 레지스트리 (ID → Info)
    private Dictionary<string, MonsterInfo> _monsterRegistry;
    private Dictionary<string, EquipmentInfo> _equipmentRegistry;
    private Dictionary<string, ItemData> _itemRegistry;

    private bool _isInitialized = false;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        // 싱글톤 설정
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("LootDataBase: 중복 인스턴스 감지, 파괴합니다.");
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("LootDataBase: 싱글톤 인스턴스 설정 완료");
    }
    #endregion

    #region Public Methods - Initialization
    /// <summary>
    /// 데이터베이스 초기화 - 풀에서 런타임 레지스트리 생성
    /// </summary>
    public void Initialize()
    {
        if (_isInitialized)
        {
            Debug.LogWarning("LootDataBase already initialized.");
            return;
        }

        _monsterRegistry = new Dictionary<string, MonsterInfo>();
        _equipmentRegistry = new Dictionary<string, EquipmentInfo>();
        _itemRegistry = new Dictionary<string, ItemData>();

        // 몬스터 레지스트리 생성
        foreach (var monster in monsterPool)
        {
            if (monster == null) continue;
            string id = monster.MonsterName;
            if (!_monsterRegistry.ContainsKey(id))
            {
                _monsterRegistry[id] = new MonsterInfo(id, monster);
            }
            else
            {
                Debug.LogWarning($"Duplicate monster ID: {id}");
            }
        }

        // 장비 레지스트리 생성 (무기 + 패시브)
        var allEquipment = new List<EquipmentData>();
        allEquipment.AddRange(weaponPool);
        allEquipment.AddRange(passivePool);

        foreach (var equipment in allEquipment)
        {
            if (equipment == null) continue;
            string id = equipment.EquipmentName;
            if (!_equipmentRegistry.ContainsKey(id))
            {
                _equipmentRegistry[id] = new EquipmentInfo(id, equipment);
            }
            else
            {
                Debug.LogWarning($"Duplicate equipment ID: {id}");
            }
        }

        // 아이템 레지스트리 생성 (간단히 Dictionary로 관리)
        foreach (var item in itemPool)
        {
            if (item == null) continue;
            string id = item.ItemName;
            if (!_itemRegistry.ContainsKey(id))
            {
                _itemRegistry[id] = item;
            }
            else
            {
                Debug.LogWarning($"Duplicate item ID: {id}");
            }
        }

        _isInitialized = true;
        Debug.Log($"LootDataBase initialized: {_monsterRegistry.Count} monsters, {_equipmentRegistry.Count} equipment, {_itemRegistry.Count} items");
    }

    /// <summary>
    /// SaveManager에서 unlock 상태 로드
    /// </summary>
    public void LoadUnlockStates()
    {
        if (!_isInitialized)
        {
            Debug.LogError("Cannot load unlock states - database not initialized!");
            return;
        }

        // 몬스터 unlock 로드
        var unlockedMonsters = SaveManager.LoadUnlockedMonsters();
        foreach (var id in unlockedMonsters)
        {
            if (_monsterRegistry.ContainsKey(id))
            {
                _monsterRegistry[id].IsUnlocked = true;
            }
        }

        // 장비 unlock 로드
        var unlockedEquipment = SaveManager.LoadUnlockedEquipment();
        foreach (var id in unlockedEquipment)
        {
            if (_equipmentRegistry.ContainsKey(id))
            {
                _equipmentRegistry[id].IsUnlocked = true;
            }
        }

        Debug.Log($"Loaded unlock states: {unlockedMonsters.Count} monsters, {unlockedEquipment.Count} equipment");
    }
    #endregion

    #region Public Methods - Query
    /// <summary>
    /// 몬스터 정보 조회
    /// </summary>
    public MonsterInfo GetMonsterInfo(string id)
    {
        return _monsterRegistry.ContainsKey(id) ? _monsterRegistry[id] : null;
    }

    /// <summary>
    /// 장비 정보 조회
    /// </summary>
    public EquipmentInfo GetEquipmentInfo(string id)
    {
        return _equipmentRegistry.ContainsKey(id) ? _equipmentRegistry[id] : null;
    }

    /// <summary>
    /// 아이템 정보 조회
    /// </summary>
    public ItemData GetItemData(string id)
    {
        return _itemRegistry.ContainsKey(id) ? _itemRegistry[id] : null;
    }

    /// <summary>
    /// 모든 몬스터 정보 리스트
    /// </summary>
    public List<MonsterInfo> GetAllMonsters()
    {
        return _monsterRegistry.Values.ToList();
    }

    /// <summary>
    /// 모든 무기 정보 리스트
    /// </summary>
    public List<EquipmentInfo> GetAllWeapons()
    {
        return _equipmentRegistry.Values.Where(e => e.Data is WeaponData).ToList();
    }

    /// <summary>
    /// 모든 패시브 정보 리스트
    /// </summary>
    public List<EquipmentInfo> GetAllPassives()
    {
        return _equipmentRegistry.Values.Where(e => e.Data is PassiveData).ToList();
    }

    /// <summary>
    /// 모든 아이템 리스트
    /// </summary>
    public List<ItemData> GetAllItems()
    {
        return _itemRegistry.Values.ToList();
    }

    /// <summary>
    /// 몬스터 unlock 여부 확인
    /// </summary>
    public bool IsMonsterUnlocked(string id)
    {
        return _monsterRegistry.ContainsKey(id) && _monsterRegistry[id].IsUnlocked;
    }

    /// <summary>
    /// 장비 unlock 여부 확인
    /// </summary>
    public bool IsEquipmentUnlocked(string id)
    {
        return _equipmentRegistry.ContainsKey(id) && _equipmentRegistry[id].IsUnlocked;
    }
    #endregion

    #region Public Methods - Unlock Management
    /// <summary>
    /// 몬스터 unlock
    /// </summary>
    public void UnlockMonster(string id)
    {
        Debug.Log($"UnlockMonster called with ID: '{id}' (length: {id?.Length ?? 0})");
        
        if (string.IsNullOrEmpty(id))
        {
            Debug.LogError("UnlockMonster: ID is null or empty!");
            return;
        }
        
        if (_monsterRegistry.ContainsKey(id))
        {
            if (!_monsterRegistry[id].IsUnlocked)
            {
                _monsterRegistry[id].IsUnlocked = true;
                SaveUnlockStates();
                Debug.Log($"Monster unlocked: {id}");
            }
            else
            {
                Debug.Log($"Monster already unlocked: {id}");
            }
        }
        else
        {
            Debug.LogWarning($"Monster ID not found in registry: '{id}'");
            Debug.Log($"Available monster IDs: {string.Join(", ", _monsterRegistry.Keys)}");
        }
    }

    /// <summary>
    /// 장비 unlock
    /// </summary>
    public void UnlockEquipment(string id)
    {
        if (_equipmentRegistry.ContainsKey(id))
        {
            if (!_equipmentRegistry[id].IsUnlocked)
            {
                _equipmentRegistry[id].IsUnlocked = true;
                SaveUnlockStates();
                Debug.Log($"Equipment unlocked: {id}");
            }
        }
        else
        {
            Debug.LogWarning($"Equipment ID not found: {id}");
        }
    }
    #endregion

    #region Public Methods - Reward Helpers
    /// <summary>
    /// 랜덤 무기 데이터 가져오기 (ScriptableObject)
    /// </summary>
    public EquipmentData GetRandomWeapon()
    {
        var weapons = GetAllWeapons();
        if (weapons.Count > 0)
        {
            var randomWeapon = weapons[Random.Range(0, weapons.Count)];
            return randomWeapon.Data;
        }
        return null;
    }

    /// <summary>
    /// 랜덤 패시브 데이터 가져오기 (ScriptableObject)
    /// </summary>
    public EquipmentData GetRandomPassive()
    {
        var passives = GetAllPassives();
        if (passives.Count > 0)
        {
            var randomPassive = passives[Random.Range(0, passives.Count)];
            return randomPassive.Data;
        }
        return null;
    }

    /// <summary>
    /// 랜덤 아이템 가져오기
    /// </summary>
    public ItemData GetRandomItem()
    {
        var items = GetAllItems();
        return items.Count > 0 ? items[Random.Range(0, items.Count)] : null;
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// unlock 상태를 SaveManager에 저장
    /// </summary>
    private void SaveUnlockStates()
    {
        // 몬스터 unlock ID 수집
        var unlockedMonsters = _monsterRegistry.Values
            .Where(m => m.IsUnlocked)
            .Select(m => m.Id)
            .ToHashSet();

        // 장비 unlock ID 수집
        var unlockedEquipment = _equipmentRegistry.Values
            .Where(e => e.IsUnlocked)
            .Select(e => e.Id)
            .ToHashSet();

        // SaveManager를 통해 저장
        SaveManager.SaveUnlockedMonsters(unlockedMonsters);
        SaveManager.SaveUnlockedEquipment(unlockedEquipment);
        SaveManager.Save();
    }
    #endregion
}
