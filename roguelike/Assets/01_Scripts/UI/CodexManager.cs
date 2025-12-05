using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CodexManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject[] allCodexPanels;

    [Header("Content")]
    [SerializeField] private Transform monsterContent; // ScrollView의 Content
    [SerializeField] private Transform equipmentContent;
    [SerializeField] private Transform itemContent;

    [Header("CodexSlot")]
    [SerializeField] private GameObject slotPrefab;

    [Header("CodexDescriptionPanel")]
    [SerializeField] private DescriptionPanel descriptionPanel;

    #region Button Action

    //ui tab키 구현
    public void OpenPanel(GameObject targetPanel)
    {
        AudioManager.Instance.PlaySfx("Select");
        foreach (GameObject panel in allCodexPanels)
        {
            if(panel==targetPanel)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }

    #endregion


    void Start()
    {
        RefreshCodex();
    }

    public void RefreshCodex()
    {
        // descriptionPanel null 체크
        if (descriptionPanel == null)
        {
            Debug.LogError("CodexManager: descriptionPanel이 할당되지 않았습니다! Inspector에서 할당해주세요.");
            return;
        }
        
        // 기존 슬롯 제거
        ClearContent(monsterContent);
        ClearContent(equipmentContent);
        ClearContent(itemContent);

        // 몬스터 도감 생성 - LootDataBase에서 조회
        foreach (var monsterInfo in LootDataBase.Instance.GetAllMonsters())
        {
            GameObject slot = Instantiate(slotPrefab, monsterContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetMonster(monsterInfo.Prefab, monsterInfo.IsUnlocked);
        }

        // 장비 도감 생성 - LootDataBase에서 조회
        foreach (var equipInfo in LootDataBase.Instance.GetAllWeapons())
        {
            GameObject slot = Instantiate(slotPrefab, equipmentContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetEquip(equipInfo.Data, equipInfo.IsUnlocked);
        }
        foreach (var equipInfo in LootDataBase.Instance.GetAllPassives())
        {
            GameObject slot = Instantiate(slotPrefab, equipmentContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetEquip(equipInfo.Data, equipInfo.IsUnlocked);
        }


        // 아이템 도감 생성 - LootDataBase에서 조회
        foreach (var item in LootDataBase.Instance.GetAllItems())
        {
            GameObject slot = Instantiate(slotPrefab, itemContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            // 아이템은 unlock 상태를 확인 (ItemData에 Unlocked 속성이 있다고 가정)
            bool isUnlocked = LootDataBase.Instance.IsEquipmentUnlocked(item.ItemName);
            ui.SetItem(item, isUnlocked);
        }
    }

    private void ClearContent(Transform content)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }


}
