/// <summary>
/// 아이템 정보 래퍼 - unlock 상태 관리용
/// </summary>
public class ItemInfo
{
    public string Id { get; private set; }
    public ItemData Data { get; private set; }
    public bool IsUnlocked { get; set; }

    public ItemInfo(string id, ItemData data)
    {
        Id = id;
        Data = data;
        IsUnlocked = data.Unlocked; // ItemData의 초기 unlock 상태 반영
    }
}
