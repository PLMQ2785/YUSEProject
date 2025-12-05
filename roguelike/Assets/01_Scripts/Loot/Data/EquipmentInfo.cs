/// <summary>
/// 장비 런타임 데이터
/// ScriptableObject의 불변 데이터와 분리하여 unlock 상태를 관리합니다.
/// </summary>
public class EquipmentInfo
{
    public string Id { get; private set; }
    public EquipmentData Data { get; private set; }
    public bool IsUnlocked { get; set; }

    public EquipmentInfo(string id, EquipmentData data, bool isUnlocked = false)
    {
        Id = id;
        Data = data;
        IsUnlocked = isUnlocked;
    }
}
