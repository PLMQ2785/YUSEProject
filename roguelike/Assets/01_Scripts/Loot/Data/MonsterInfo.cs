/// <summary>
/// 몬스터 런타임 데이터
/// ScriptableObject의 불변 데이터와 분리하여 unlock 상태를 관리합니다.
/// </summary>
public class MonsterInfo
{
    public string Id { get; private set; }
    public Monster Prefab { get; private set; }
    public bool IsUnlocked { get; set; }

    public MonsterInfo(string id, Monster prefab, bool isUnlocked = false)
    {
        Id = id;
        Prefab = prefab;
        IsUnlocked = isUnlocked;
    }
}
