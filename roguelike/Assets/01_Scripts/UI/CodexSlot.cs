using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CodexSlot : MonoBehaviour
{
    [SerializeField] private Button slot;
    [SerializeField] private Image slotIcon;
    [SerializeField] private Sprite slotSilhouette;

    private DescriptionPanel _descriptionPanel;


    // 몬스터 슬롯 설정
    public void SetMonster(Monster data, bool unlocked)
    {
        Debug.Log($"CodexSlot.SetMonster: {data.MonsterName}, unlocked={unlocked}, icon={data.Icon?.name ?? "null"}");
        slotIcon.sprite = unlocked ? data.Icon : slotSilhouette;

        slot.onClick.RemoveAllListeners();
        slot.onClick.AddListener(() => _descriptionPanel.ShowMonster(data, unlocked));
    }

    // 아이템 슬롯 설정
    public void SetItem(ItemData data, bool unlocked)
    {
        slotIcon.sprite = unlocked ? data.Icon : slotSilhouette;

        slot.onClick.RemoveAllListeners();
        slot.onClick.AddListener(() => _descriptionPanel.ShowItem(data, unlocked));
    }

    // 장비 슬롯 설정
    public void SetEquip(EquipmentData data, bool unlocked)
    {
        slotIcon.sprite = unlocked ? data.Icon : slotSilhouette;

        slot.onClick.RemoveAllListeners();
        slot.onClick.AddListener(() => _descriptionPanel.ShowEquip(data, unlocked));
    }

    public void SetDescriptionPanel(DescriptionPanel panel)
    {
        _descriptionPanel = panel;
    }
}
