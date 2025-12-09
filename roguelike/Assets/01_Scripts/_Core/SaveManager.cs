using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    #region Constants (Key Definitions)
    // 상수
    private const string KEY_GOLD = "Player_Gold";
    private const string KEY_MASTER_VOLUME = "Setting_MasterVolume";
    private const string KEY_BGM_VOLUME = "Setting_BgmVolume";
    private const string KEY_SFX_VOLUME = "Setting_SfxVolume";
    
    private const string KEY_RES_WIDTH = "Setting_ResWidth";
    private const string KEY_RES_HEIGHT = "Setting_ResHeight";
    private const string KEY_IS_FULLSCREEN = "Setting_IsFullScreen";
    
    // 업그레이드 키 접두사 미리 만들어둔것.
    private const string KEY_UPGRADE_PREFIX = "Upgrade_";
    
    // Codex unlock 키
    private const string KEY_UNLOCKED_MONSTERS = "Codex_UnlockedMonsters";
    private const string KEY_UNLOCKED_EQUIPMENT = "Codex_UnlockedEquipment";
    private const string KEY_UNLOCKED_ITEMS = "Codex_UnlockedItems";
    
    /// <summary>
    /// JSON 직렬화용 래퍼 클래스
    /// </summary>
    [System.Serializable]
    private class UnlockData
    {
        public List<string> unlockedIds = new List<string>();
    }
    #endregion
    
    //저장부분
    #region Public Methods (General)
    public static void Save()
    {
        //저장
        PlayerPrefs.Save();
    }
    
    public static void DeleteAll()
    {
        //삭제
        PlayerPrefs.DeleteAll();
        Save();
    }
    
    //조회
    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
    #endregion
    
    //골-드
    #region Public Methods (Gold)
    public static void SaveGold(int amount)
    {
        PlayerPrefs.SetInt(KEY_GOLD, amount);
    }

    public static int LoadGold()
    {
        // 저장된 값이 없으면 0
        return PlayerPrefs.GetInt(KEY_GOLD, 0);
    }
    #endregion
    
    #region Public Methods (Upgrade Levels)
    /// <summary>
    /// 특정 능력치 강화 레벨 저장
    /// </summary>
    public static void SaveUpgradeLevel(UpgradeType upgradeType, int level)
    {
        string key = GetUpgradeKey(upgradeType);
        PlayerPrefs.SetInt(key, level);
    }
    
    /// <summary>
    /// 특정 능력치 강화 레벨 불러옴
    /// </summary>
    public static int LoadUpgradeLevel(UpgradeType upgradeType)
    {
        string key = GetUpgradeKey(upgradeType);
        // 기본 레벨은 0
        return PlayerPrefs.GetInt(key, 0);
    }
    
    private static string GetUpgradeKey(UpgradeType upgradeType)
    {
        return $"{KEY_UPGRADE_PREFIX}{upgradeType}";
    }
    #endregion

    #region Public Methods (Codex Unlock)
    /// <summary>
    /// 몬스터 unlock 목록 저장
    /// </summary>
    public static void SaveUnlockedMonsters(HashSet<string> unlockedIds)
    {
        var data = new UnlockData { unlockedIds = new List<string>(unlockedIds) };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(KEY_UNLOCKED_MONSTERS, json);
    }

    /// <summary>
    /// 몬스터 unlock 목록 불러오기
    /// </summary>
    public static HashSet<string> LoadUnlockedMonsters()
    {
        string json = PlayerPrefs.GetString(KEY_UNLOCKED_MONSTERS, "");
        if (string.IsNullOrEmpty(json))
            return new HashSet<string>();
        
        var data = JsonUtility.FromJson<UnlockData>(json);
        return new HashSet<string>(data.unlockedIds);
    }

    /// <summary>
    /// 장비 unlock 목록 저장
    /// </summary>
    public static void SaveUnlockedEquipment(HashSet<string> unlockedIds)
    {
        var data = new UnlockData { unlockedIds = new List<string>(unlockedIds) };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(KEY_UNLOCKED_EQUIPMENT, json);
    }

    /// <summary>
    /// 장비 unlock 목록 불러오기
    /// </summary>
    public static HashSet<string> LoadUnlockedEquipment()
    {
        string json = PlayerPrefs.GetString(KEY_UNLOCKED_EQUIPMENT, "");
        if (string.IsNullOrEmpty(json))
            return new HashSet<string>();
        
        var data = JsonUtility.FromJson<UnlockData>(json);
        return new HashSet<string>(data.unlockedIds);
    }
    
    /// <summary>
    /// 아이템 unlock 목록 저장
    /// </summary>
    public static void SaveUnlockedItems(HashSet<string> unlockedIds)
    {
        var data = new UnlockData { unlockedIds = new List<string>(unlockedIds) };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(KEY_UNLOCKED_ITEMS, json);
    }

    /// <summary>
    /// 아이템 unlock 목록 불러오기
    /// </summary>
    public static HashSet<string> LoadUnlockedItems()
    {
        string json = PlayerPrefs.GetString(KEY_UNLOCKED_ITEMS, "");
        if (string.IsNullOrEmpty(json))
            return new HashSet<string>();
        
        var data = JsonUtility.FromJson<UnlockData>(json);
        return new HashSet<string>(data.unlockedIds);
    }
    #endregion

    #region Public Methods (Settings)
    public static void SaveVolume(string volumeType, float value)
    {
        switch (volumeType)
        {
            case "Master": PlayerPrefs.SetFloat(KEY_MASTER_VOLUME, value); break;
            case "BGM": PlayerPrefs.SetFloat(KEY_BGM_VOLUME, value); break;
            case "SFX": PlayerPrefs.SetFloat(KEY_SFX_VOLUME, value); break;
        }
    }

    public static float LoadVolume(string volumeType, float defaultValue = 1.0f)
    {
        switch (volumeType)
        {
            case "Master": return PlayerPrefs.GetFloat(KEY_MASTER_VOLUME, defaultValue);
            case "BGM": return PlayerPrefs.GetFloat(KEY_BGM_VOLUME, defaultValue);
            case "SFX": return PlayerPrefs.GetFloat(KEY_SFX_VOLUME, defaultValue);
            default: return defaultValue;
        }
    }
    
    public static void SaveResolutionSettings(int width, int height, bool isFullScreen)
    {
        PlayerPrefs.SetInt(KEY_RES_WIDTH, width);
        PlayerPrefs.SetInt(KEY_RES_HEIGHT, height);
        // PlayerPrefs는 bool이 없으므로 int(1=true, 0=false)로 변환 저장
        PlayerPrefs.SetInt(KEY_IS_FULLSCREEN, isFullScreen ? 1 : 0);
    }
    
    public static (int width, int height, bool isFullScreen) LoadResolutionSettings()
    {
        // 기본값: 현재 스크린 해상도
        int defaultWidth = Screen.width;
        int defaultHeight = Screen.height;
        int defaultFull = Screen.fullScreen ? 1 : 0;

        int w = PlayerPrefs.GetInt(KEY_RES_WIDTH, defaultWidth);
        int h = PlayerPrefs.GetInt(KEY_RES_HEIGHT, defaultHeight);
        bool full = PlayerPrefs.GetInt(KEY_IS_FULLSCREEN, defaultFull) == 1;

        return (w, h, full);
    }
    #endregion
}
