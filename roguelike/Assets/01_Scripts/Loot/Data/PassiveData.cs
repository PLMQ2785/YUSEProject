using UnityEngine;
/// <summary>
/// 패시브 아이템 전용 데이터 (ScriptableObject)
/// UpgradeType을 사용하여 PlayerStats와 통합된 스탯 시스템을 제공합니다.
/// </summary>
[CreateAssetMenu(fileName = "New Passive Data", menuName = "Scriptable Objects/Equipment/Passive Data")]
public class PassiveData : EquipmentData
{
    [Header("Passive Stats")]
    [SerializeField] private UpgradeType statType;
    [SerializeField] private float statValue; // 증가량 (예: 10, 0.1 등)
    public UpgradeType StatType => statType;
    public float StatValue => statValue;
}