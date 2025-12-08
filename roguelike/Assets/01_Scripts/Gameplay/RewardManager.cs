using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    #region Events
    // (컨벤션 1-3) GameManager가 구독할 이벤트
    // (SDS 3.2.1 HandleRewardFinished)
    public event Action OnRewardProcessFinished;

    // rewardPanel UI 변경 이벤트
    public event Action<int,int,float> OnRewardTextUIChanged;
    public event Action<List<ScriptableObject>> OnRewardUIChanged;
    #endregion

    #region Serialized Fields
    // (Sprint 2에서 PlayerManager 등 다른 의존성을 이곳에 연결)
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private LootDataBase lootDataBase;
    [SerializeField] private InventoryManager inventoryManager;

    #endregion

    #region Private Fields
    private int _maxRerollCount = 2; // 테스트용 임시 최대 리롤 횟수
    private int _rerollCount = 0;
    private int _baseRerollPrice = 100; // 테스트용 임시 리롤 비용
    private int _rerollPrice = 0;
    private float _skipExpRatio = 0.2f; // 테스트용 임시 경험치 보상 비율
    #endregion

    #region Unity LifeCycle
    private void Start()
    {
        if (playerManager == null)
            Debug.LogError("RewardManager: PlayerManager가 인스펙터에 연결되지 않았습니다!");

        _rerollPrice = _baseRerollPrice;
        _rerollCount = _maxRerollCount;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// (S2, B-4) GameManager가 레벨업을 감지하면 호출
    /// 보상 3개 생성
    /// </summary>
    public void GenerateRewards()
    {
        // HUDManager에서 rewarTextUI 업데이트
        OnRewardTextUIChanged?.Invoke(_rerollPrice,_rerollCount,_skipExpRatio);
        Debug.Log("RewardManager: GenerateRewards() 호출됨");
        
        // 아이템,장비,패시브의 최상위 ScriptableObject 타입 최종 보상셋
        HashSet<ScriptableObject> rewards = new HashSet<ScriptableObject>(3);
        // 무한 루프 방지용 안전 장치 (보유 아이템이 없는데 뽑으려 할 때 등 대비)
        int safetyCount = 0; 
        while (rewards.Count < 3 && safetyCount < 100)
        {
            safetyCount++;
            ScriptableObject select = null;
            // (장비,아이템 풀 구분) 10개 중 랜덤으로 뽑기
            int flag = UnityEngine.Random.Range(0, 10);
            // 20% 확률로 소모품(Item) 등장
            if (flag >= 8)
            {
                // 이미 보유한 아이템 제외
                var allItems = LootDataBase.Instance.GetAllItems();
                var ownedItemNames = inventoryManager.Consumables.Select(i => i.Data.ItemName).ToHashSet();
                var availableItems = allItems.Where(item => !ownedItemNames.Contains(item.ItemName)).ToList();
                
                if (availableItems.Count > 0)
                {
                    select = availableItems[UnityEngine.Random.Range(0, availableItems.Count)];
                }
                // 모든 아이템을 이미 가지고 있으면 null (다른 보상 선택하도록)
            }
            else
            {
                // (장비 구분) 3개 중 랜덤으로 뽑기
                int flag2 = UnityEngine.Random.Range(0, 3);
                // 40% 확률로 [현재 보유한 장비]에서 등장 (업그레이드)
                // 최대 레벨이 아닌 장비만 필터링
                var upgradeableWeapons = inventoryManager.Weapons
                    .Where(w => w.Level < w.Data.MaxLevel)
                    .ToList();
                var upgradeablePassives = inventoryManager.Passives
                    .Where(p => p.Level < p.Data.MaxLevel)
                    .ToList();
                if (flag < 4 && (upgradeablePassives.Count > 0 || upgradeableWeapons.Count > 0))
                {
                    // 1/3 확률로 패시브, 2/3 확률로 무기
                    bool wantPassive = (flag2 == 0);
    
                    // 원하는 타입이 업그레이드 가능하면 선택
                    if (wantPassive && upgradeablePassives.Count > 0)
                    {
                        select = upgradeablePassives[UnityEngine.Random.Range(0, upgradeablePassives.Count)].PassiveData;
                    }
                    else if (!wantPassive && upgradeableWeapons.Count > 0)
                    {
                        select = upgradeableWeapons[UnityEngine.Random.Range(0, upgradeableWeapons.Count)].WeaponData;
                    }
                    // 원하는 타입이 없으면 반대 타입 시도
                    else if (upgradeableWeapons.Count > 0)
                    {
                        select = upgradeableWeapons[UnityEngine.Random.Range(0, upgradeableWeapons.Count)].WeaponData;
                    }
                    else if (upgradeablePassives.Count > 0)
                    {
                        select = upgradeablePassives[UnityEngine.Random.Range(0, upgradeablePassives.Count)].PassiveData;
                    }
                    // 둘 다 최대 레벨이면 select는 null -> 전체 풀에서 선택하도록 루프 재시도
                }
                // 60% 확률 (혹은 보유 장비가 없을 때) -> 전체 풀에서 등장 (신규 획득)
                else
                {
                    // 1/3 확률로 패시브 등장
                    if (flag2 == 0)
                    {
                        if (inventoryManager.IsPassiveFull)
                        {
                            // 이미 보유한 아이템 제외
                            var allItems = LootDataBase.Instance.GetAllItems();
                            var ownedItemNames = inventoryManager.Consumables.Select(i => i.Data.ItemName).ToHashSet();
                            var availableItems = allItems.Where(item => !ownedItemNames.Contains(item.ItemName)).ToList();
                            
                            if (availableItems.Count > 0)
                            {
                                select = availableItems[UnityEngine.Random.Range(0, availableItems.Count)];
                            }
                        }
                        else
                        {
                            select = LootDataBase.Instance.GetRandomPassive();
                        }
                    }
                    // 2/3 확률로 무기 등장
                    else
                    {
                        if (inventoryManager.IsWeaponFull)
                        {
                            // 이미 보유한 아이템 제외
                            var allItems = LootDataBase.Instance.GetAllItems();
                            var ownedItemNames = inventoryManager.Consumables.Select(i => i.Data.ItemName).ToHashSet();
                            var availableItems = allItems.Where(item => !ownedItemNames.Contains(item.ItemName)).ToList();
                            
                            if (availableItems.Count > 0)
                            {
                                select = availableItems[UnityEngine.Random.Range(0, availableItems.Count)];
                            }
                        }
                        else
                        {
                            select = LootDataBase.Instance.GetRandomWeapon();
                        }
                    }
                }
            }
            if (select != null)
            {
                rewards.Add(select);
            }
        }
        Debug.Log($"RewardManager: Generated {rewards.Count} rewards");
        
        // HUDManager에서 RewardUI 업데이트
        OnRewardUIChanged?.Invoke(rewards.ToList());
    }
    
    /// <summary>
    /// 보상 선택 시 호출
    /// </summary>
    public void OnRewardSelected(ScriptableObject data) 
    {
        // 선택된 보상 장착 (장비, 아이템 구분)
        switch (data)
        {
            case ItemData item:
                Debug.Log("RewardManager: 아이템 선택");

                // 아이템 추가
                playerManager.AddItem(item);
                
                break;

            case EquipmentData equipment:
                Debug.Log("RewardManager: 장비 선택");

                // 장비 추가
                playerManager.AddEquipment(equipment);

                break;
        }

        // 리롤 횟수 초기화
        _rerollCount = _maxRerollCount;
        // 리롤 비용 초기화
        _rerollPrice = _baseRerollPrice;

        OnRewardProcessFinished?.Invoke();
    }

    /// <summary>
    /// 리롤: 새로운 보상 3개 다시 생성
    /// 리롤 가격만큼 골드 차감
    /// </summary>
    public void OnRerollPressed() 
    {
        if (playerManager.Gold < _rerollPrice)
        {
            Debug.Log("RewardManager: 골드 부족 -> 리롤 불가");
            return;
        }

        if (_rerollCount <= 0)
        {
            Debug.Log("RewardManager: 리롤 횟수 부족 -> 리롤 불가");
            return;
        }

        // 골드 차감
        if (!playerManager.SpendGold(_rerollPrice))
        {
            Debug.LogWarning("RewardManager: Failed to spend gold (this shouldn't happen as we already checked)");
            return;
        }

        // 리롤 횟수 감소
        _rerollCount--;
        // 리롤 비용 증가
        _rerollPrice = _rerollPrice * 2; // 임시 2배 증가

        // 보상 다시 생성
        GenerateRewards();
    }

    /// <summary>
    /// 보상 스킵
    /// </summary>
    public void OnSkipPressed() 
    {
        // 경험치 보상 후 종료
        playerManager.GainExp((int)(playerManager.MaxExp * _skipExpRatio)); // 테스트용 임시 경험치 보상

        // 리롤 횟수 초기화
        _rerollCount = _maxRerollCount;
        // 리롤 비용 초기화
        _rerollPrice = _baseRerollPrice;

        OnRewardProcessFinished?.Invoke();
    }
    #endregion

    #region Private Methods

    #endregion
}