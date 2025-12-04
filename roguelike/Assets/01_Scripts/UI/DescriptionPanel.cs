using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPanel : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image descriptionIcon;
    [SerializeField] private TextMeshProUGUI descriptionNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Sprite descriptionSilhouette;

    // 몬스터 상세 표시
    public void ShowMonster(Monster data, bool unlocked)
    {
        gameObject.SetActive(true);

        descriptionIcon.sprite = unlocked ? data.Icon : descriptionSilhouette;
        descriptionNameText.text = unlocked ? data.MonsterName : "???";
        descriptionText.text = unlocked ? data.Description : "해금되지 않은 정보입니다.";
    }

    // 아이템 상세 표시
    public void ShowItem(ItemData data, bool unlocked)
    {
        gameObject.SetActive(true);

        descriptionIcon.sprite = unlocked ? data.Icon : descriptionSilhouette;
        descriptionNameText.text = unlocked ? data.ItemName : "???";
        descriptionText.text = unlocked ? data.Description : "해금되지 않은 정보입니다.";
    }

    // 장비 상세 표시
    public void ShowEquip(EquipmentData data, bool unlocked)
    {
        gameObject.SetActive(true);

        descriptionIcon.sprite = unlocked ? data.Icon : descriptionSilhouette;
        descriptionNameText.text = unlocked ? data.EquipmentName : "???";
        descriptionText.text = unlocked ? data.Description : "해금되지 않은 정보입니다.";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
