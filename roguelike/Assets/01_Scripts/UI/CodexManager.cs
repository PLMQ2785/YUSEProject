using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CodexManager : MonoBehaviour
{
    [Header("DataBase")]
    [SerializeField] private MonsterDataBase monsterDataBase; // 몬스터 db
    [SerializeField] private LootDataBase lootDataBase; // 장비 db

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
        // 기존 슬롯 제거
        ClearContent(monsterContent);
        ClearContent(equipmentContent);
        ClearContent(itemContent);

        if (monsterDataBase == null) { Debug.Log("monsterDB null"); return; }
        // 몬스터 도감 생성
        foreach (var monster in monsterDataBase.monsterPool)
        {
            GameObject slot = Instantiate(slotPrefab, monsterContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetMonster(monster, monster.Unlocked);
        }

        if(lootDataBase == null) { Debug.Log("lootDB null"); return; }
        // 장비 도감 생성
        foreach (var equip in lootDataBase.weaponPool)
        {
            GameObject slot = Instantiate(slotPrefab, equipmentContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetEquip(equip, equip.Unlocked);
        }
        foreach (var equip in lootDataBase.passivePool)
        {
            GameObject slot = Instantiate(slotPrefab, equipmentContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetEquip(equip, equip.Unlocked);
        }


        // 아이템 도감 생성
        foreach (var item in lootDataBase.itemPool)
        {
            GameObject slot = Instantiate(slotPrefab, itemContent);
            var ui = slot.GetComponent<CodexSlot>();

            ui.SetDescriptionPanel(descriptionPanel);
            ui.SetItem(item, item.Unlocked);
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
