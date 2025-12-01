using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class HUDManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Dependencies")]
    [SerializeField] private PlayerManager playerManager; // 인스펙터에서 연결
    [SerializeField] private InventoryManager inventoryManager; // 획득한 장비와 아이템 띄우기 위한 참조
    [SerializeField] private RewardManager rewardManager; // 보상 UI를 위한 참조

    [Header("UI Elements (S1)")]
    [SerializeField] private Slider hpSlider; // (D-1.a)
    [SerializeField] private Slider expSlider; // (D-1.a)
    [SerializeField] private TextMeshProUGUI timerText; // (D-1.b)

    [Header("UI Elements (S3)")]
    [SerializeField] private TextMeshProUGUI goldText; // (D-1.b)
    [SerializeField] private TextMeshProUGUI killCountText; // (D-1.b)
    [SerializeField] private GameObject bossHpBarPanel; // (D-1.d)
    [SerializeField] private GameObject questInfoPanel; // (D-1.d)
    
    [Header("Slots (S3, D-1.c)")]
    [SerializeField] private Image[] weaponSlots; // 공격형 장비 슬롯 (6개)
    [SerializeField] private Image[] passiveSlots; // 패시브 장비 슬롯 (6개)
    [SerializeField] private Image[] itemSlots; // 아이템 슬롯 (3개)

    [Header("RewardPanel UI")]
    [SerializeField] private Button[] rewardSlots; // 보상 슬롯 버튼
    [SerializeField] private Image[] rewardsIcon; // 보상 아이콘
    [SerializeField] private Text[] rewardsDescription; // 보상 설명 텍스트
    [SerializeField] private TextMeshProUGUI rerollCostText; // 리롤 비용 텍스트
    [SerializeField] private TextMeshProUGUI rerollCountText; // 리롤 횟수 텍스트
    [SerializeField] private TextMeshProUGUI skipExpRatio; // 스킵 시 경험치 보상 텍스트
    #endregion

    #region Unity LifeCycle
    private void Start()
    {
        // 안전 장치
        if (playerManager == null)
        {
            Debug.LogError("HUDManager: PlayerManager가 인스펙터에 할당되지 않았습니다!");
            return;
        }

        // --- 이벤트 구독 ---

        // [Sprint 1]
        // GameManager(싱글톤)의 시간 이벤트 구독
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnTimeChanged += UpdateTimerText;
        }
        
        // PlayerManager(SerializeField)의 HP 이벤트 구독
        playerManager.OnHpChanged += UpdateHpBar;
        
        // [Sprint 2 & 3]
        // PlayerManager의 EXP, Gold, Kill 이벤트 구독
        playerManager.OnExpChanged += UpdateExpBar;
        playerManager.OnGoldChanged += UpdateGoldText;
        playerManager.OnKillCountChanged += UpdateKillCountText;

        // (S3) [패키지 3]의 이벤트도 구독해야 함
        // SpawnManager.OnBossSpawned += ShowBossHpBar;
        // QuestManager.OnQuestStarted += ToggleQuestInfo;

        // [Inventory]
        if (inventoryManager != null)
        {
            Debug.Log("[HUDManager] Subscribing to InventoryManager events.");
            inventoryManager.OnInventoryChanged += UpdateInventoryUI;
        }
        else
        {
            Debug.LogError("[HUDManager] InventoryManager is NULL in Start!");
        }

        // RewardUI
        if (rewardManager == null)
        {
            Debug.LogError("[HUDManager] RewardManager is NULL");
        }
        else
        {
            rewardManager.OnRewardTextUIChanged += UpdateRewardTextUI;
            rewardManager.OnRewardUIChanged += UpdateRewardUI;
        }

        InitHUD();
    }

    private void OnDestroy()
    {
        // --- (컨벤션 1-3) 이벤트 구독 해제 (메모리 누수 방지) ---

        // GameManager가 null이 아닌지 확인 (게임 종료 시 Instance가 먼저 파괴될 수 있음)
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnTimeChanged -= UpdateTimerText;
        }

        if (playerManager != null)
        {
            playerManager.OnHpChanged -= UpdateHpBar;
            playerManager.OnExpChanged -= UpdateExpBar;
            playerManager.OnGoldChanged -= UpdateGoldText;
            playerManager.OnKillCountChanged -= UpdateKillCountText;
        }

        // (S3) [패키지 3] 이벤트 구독 해제
        // SpawnManager.OnBossSpawned -= ShowBossHpBar;
        // QuestManager.OnQuestStarted -= ToggleQuestInfo;

        if (inventoryManager != null)
        {
            inventoryManager.OnInventoryChanged -= UpdateInventoryUI;
        }

        if (rewardManager != null) 
        { 
            rewardManager.OnRewardTextUIChanged -= UpdateRewardTextUI;
            rewardManager.OnRewardUIChanged -= UpdateRewardUI;
        }
    }
    #endregion

    #region Private Methods (Event Handlers)
    // (컨벤션 1-3)
    // Update()가 아닌, 이벤트가 "방송"될 때만 호출되는 함수들입니다.

    /// <summary>
    /// (S1, D-1.a) PlayerManager.OnHpChanged 이벤트가 호출
    /// </summary>
    private void UpdateHpBar(float currentHp, float maxHp)
    {
        if (hpSlider != null)
            hpSlider.value = currentHp / maxHp;
    }

    /// <summary>
    /// (S2, D-1.a) PlayerManager.OnExpChanged 이벤트가 호출
    /// </summary>
    private void UpdateExpBar(float currentExp, float maxExp)
    {
        if (expSlider != null)
            expSlider.value = currentExp / maxExp;
    }

    /// <summary>
    /// (S1, D-1.b) GameManager.OnTimeChanged 이벤트가 호출
    /// </summary>
    private void UpdateTimerText(float time)
    {
        if (!timerText) return;
        
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
    
    /// <summary>
    /// (S3, D-1.b) PlayerManager.OnGoldChanged 이벤트가 호출
    /// </summary>
    private void UpdateGoldText(int amount)
    {
        if (goldText != null)
            goldText.text = amount.ToString();
    }
    
    /// <summary>
    /// (S3, D-1.b) PlayerManager.OnKillCountChanged 이벤트가 호출
    /// </summary>
    private void UpdateKillCountText(int amount)
    {
        if (killCountText != null)
            killCountText.text = amount.ToString();
    }

    // (S3, D-1.d)
    // private void ShowBossHpBar(...) { ... }
    // private void ToggleQuestInfo(...) { ... }

    /// <summary>
    /// HUD 초기화
    /// </summary>
    private void InitHUD()
    {
        // HP
        UpdateHpBar(playerManager.CurrentHp, playerManager.CurrentHp);

        // EXP
        UpdateExpBar(playerManager.CurrentExp, 1);

        // Timer
        UpdateTimerText(0);

        // Gold
        UpdateGoldText(playerManager.Gold);

        // Kill Count
        UpdateKillCountText(0);

        // Boss HP Bar 숨김
        if (bossHpBarPanel != null)
            bossHpBarPanel.SetActive(false);

        // Quest 패널 숨김
        if (questInfoPanel != null)
            questInfoPanel.SetActive(false);

        // 인벤토리 UI 초기화
        UpdateInventoryUI();
    }

    /// <summary>
    /// (S3, D-1.c) InventoryManager.OnInventoryChanged 이벤트가 호출
    /// 장비 및 아이템 슬롯 UI를 갱신합니다.
    /// </summary>
    private void UpdateInventoryUI()
    {
        if (inventoryManager == null) return;

        Debug.Log($"[HUDManager] UpdateInventoryUI Called. Weapons: {inventoryManager.Weapons.Count}, Passives: {inventoryManager.Passives.Count}, Items: {inventoryManager.Consumables.Count}");

        // 1. 무기 슬롯 갱신
        UpdateSlots(weaponSlots, inventoryManager.Weapons.ConvertAll(w => w.WeaponData.Icon));

        // 2. 패시브 슬롯 갱신
        UpdateSlots(passiveSlots, inventoryManager.Passives.ConvertAll(p => p.Data.Icon));

        // 3. 아이템 슬롯 갱신
        UpdateSlots(itemSlots, inventoryManager.Consumables.ConvertAll(i => i.Data.Icon));
    }

    /// <summary>
    /// 슬롯 배열을 데이터 리스트에 맞춰 갱신하는 헬퍼 함수
    /// </summary>
    private void UpdateSlots(Image[] slots, List<Sprite> icons)
    {
        if (slots == null) return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null) continue;

            if (i < icons.Count)
            {
                // 아이템이 있는 경우
                slots[i].sprite = icons[i];
                slots[i].enabled = true;
                
                // 투명도가 0이 아니도록 설정 (혹시 모를 안전장치)
                Color c = slots[i].color;
                c.a = 1f;
                slots[i].color = c;
            }
            else
            {
                // 아이템이 없는 경우
                slots[i].sprite = null;
                slots[i].enabled = false; // 이미지를 끄거나 투명하게 처리
            }
        }
    }

    /// <summary>
    /// 보상창 텍스트 업데이트 함수
    /// RewardManager.onRewardTextUIChanged 이벤트가 호출
    /// </summary>
    private void UpdateRewardTextUI(int cost, int count, float ratio)
    {
        // 리롤 비용 업데이트
        if (rerollCostText != null)
            rerollCostText.text = cost.ToString();

        // 리롤 비용 지불 불가능 시 빨간색으로 표시
        if (cost > playerManager.Gold)
        {
            rerollCostText.color = Color.red;
        }
        else
        {
            rerollCostText.color = Color.white;
        }

        // 리롤 횟수 업데이트
        if (rerollCountText != null)
            rerollCountText.text = count.ToString();

        // 리롤 횟수 부족 시 빨간색으로 표시
        if (count > 0)
        {
            rerollCountText.color = Color.white;
        }
        else
        {
            rerollCountText.color = Color.red;
        }

        // 스킵시 경험치 보상 비율 업데이트
        if (skipExpRatio != null)
            skipExpRatio.text = $"{ratio * 100}%";
    }

    /// <summary>
    /// 보상창 보상카드 업데이트 함수
    /// RewardManager.onRewardUIChanged 이벤트가 호출
    /// </summary>
    private void UpdateRewardUI(List<ScriptableObject> rewards)
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            // UI 교체
            switch (rewards[i])
            {
                case ItemData item:
                    rewardsIcon[i].sprite = item.Icon;
                    rewardsDescription[i].text = item.Description;
                    break;

                case EquipmentData equip:
                    rewardsIcon[i].sprite = equip.Icon;
                    rewardsDescription[i].text = equip.Description;
                    break;

            }

            // 기존 리스너 제거 후 새로 등록
            rewardSlots[i].onClick.RemoveAllListeners();
            rewardSlots[i].onClick.AddListener(() =>
            {
                rewardManager.OnRewardSelected(rewards[i]);
            });
        }
    }

    #endregion
}