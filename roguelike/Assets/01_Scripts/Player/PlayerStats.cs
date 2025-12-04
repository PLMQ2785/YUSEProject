using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 스탯을 관리합니다.
/// 기본 스탯과 업그레이드 보너스를 분리하여 관리합니다.
/// </summary>
[Serializable]
public class PlayerStats
{
    #region Serialized Fields (Base Stats)
    [Header("기본 스탯")]
    [SerializeField] private float maxHp = 100f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float attackDamageMult = 1f;
    [SerializeField] private float attackSpeedMult = 1f;
    [SerializeField] private float cooldownMult = 1f;
    [SerializeField] private float magnetRange = 2f;
    [SerializeField] private float critChance = 5f;
    [SerializeField] private float critDamageMult = 1.5f;
    [SerializeField] private float expMult = 1f;
    [SerializeField] private float goldMult = 1f;
    [SerializeField] private float damageReductionMult = 0f;
    #endregion

    #region Private Fields (Bonuses)
    // 영구 업그레이드 전용 (정적, 게임 시작 시 1회 적용)
    private Dictionary<UpgradeType, float> _permanentBonuses = new Dictionary<UpgradeType, float>();
    
    // 패시브 장비 전용 (동적, 게임 중 추가/레벨업/제거 가능)
    private Dictionary<UpgradeType, Dictionary<object, float>> _passiveBonuses = new Dictionary<UpgradeType, Dictionary<object, float>>();
    
    // 3. [추가] 이벤트 버프/디버프 (동적, Source 기반)
    private Dictionary<UpgradeType, Dictionary<object, float>> _eventBonuses = new Dictionary<UpgradeType, Dictionary<object, float>>();
    #endregion

    #region Properties (Final Stats)
    
    public float MaxHp => maxHp + GetBonus(UpgradeType.Hp);
    public float Speed => speed + GetBonus(UpgradeType.Speed);
    public float AttackDamageMult => attackDamageMult + GetBonus(UpgradeType.AttackDamageMult);
    public float AttackSpeedMult => attackSpeedMult + GetBonus(UpgradeType.AttackSpeedMult);
    public float CooldownMult => Mathf.Max(0.1f, cooldownMult - GetBonus(UpgradeType.CooldownMult));
    public float MagnetRange => magnetRange + GetBonus(UpgradeType.MagnetRange);
    public float CritChance => critChance + GetBonus(UpgradeType.CritChance);
    public float CritDamageMult => critDamageMult + GetBonus(UpgradeType.CritDamageMult);
    public float ExpMult => expMult + (GetBonus(UpgradeType.ExpMult));
    public float GoldMult => goldMult + (GetBonus(UpgradeType.GoldMult) / 100f);
    public float DamageReductionMult => damageReductionMult + GetBonus(UpgradeType.DamageReductionMult);
    
    #endregion

    #region Public Methods
    /// <summary>
    /// 영구 업그레이드 보너스를 설정합니다. (UpgradeManager 전용)
    /// </summary>
    public void SetPermanentBonus(UpgradeType type, float value)
    {
        _permanentBonuses[type] = value;
    }

    /// <summary>
    /// 패시브 장비 보너스를 설정합니다. (Passive 전용)
    /// 각 패시브 아이템은 자신을 소스로 등록하여 여러 아이템의 보너스가 공존할 수 있습니다.
    /// </summary>
    /// <param name="type">스탯 타입</param>
    /// <param name="source">보너스 소스 (패시브 아이템 인스턴스)</param>
    /// <param name="value">보너스 값</param>
    public void SetPassiveBonus(UpgradeType type, object source, float value)
    {
        if (!_passiveBonuses.ContainsKey(type))
        {
            _passiveBonuses[type] = new Dictionary<object, float>();
        }
        
        _passiveBonuses[type][source] = value;
    }

    /// <summary>
    /// 패시브 장비 보너스를 제거합니다. (장비 제거 시 사용)
    /// </summary>
    public void RemovePassiveBonus(UpgradeType type, object source)
    {
        if (_passiveBonuses.ContainsKey(type))
        {
            _passiveBonuses[type].Remove(source);
        }
    }

    /// <summary>
    /// 특정 타입의 총 보너스를 가져옵니다. (영구 업그레이드 + 모든 패시브 장비)
    /// </summary>
    public float GetBonus(UpgradeType type)
    {
        float total = 0f;
        
        // 1. 영구 업그레이드 보너스
        if (_permanentBonuses.ContainsKey(type))
        {
            total += _permanentBonuses[type];
        }
        
        // 2. 모든 패시브 장비 보너스 합산
        if (_passiveBonuses.ContainsKey(type))
        {
            foreach (var bonus in _passiveBonuses[type].Values)
            {
                total += bonus;
            }
            total += _permanentBonuses[type];
        }
        
        // 2. 모든 패시브 장비 보너스 합산
        if (_passiveBonuses.ContainsKey(type))
        {
            foreach (var bonus in _passiveBonuses[type].Values)
            {
                total += bonus;
            }
        }
        
        // 3. (추가) 이벤트 효과
        if (_eventBonuses.ContainsKey(type))
        {
            foreach (var bonus in _eventBonuses[type].Values)
            {
                total += bonus;
            }
        }
        
        return total;
    }

    /// <summary>
    /// 모든 보너스를 초기화합니다.
    /// </summary>
    public void ClearBonuses()
    {
        _permanentBonuses.Clear();
        _passiveBonuses.Clear();
    }
    
    // 이벤트 효과 적용
    public void AddEventBonus(UpgradeType type, object source, float value)
    {
        if (!_eventBonuses.ContainsKey(type))
        {
            _eventBonuses[type] = new Dictionary<object, float>();
        }
        _eventBonuses[type][source] = value;
    }
    
    // 이벤트 효과 제거
    public void RemoveEventBonus(UpgradeType type, object source)
    {
        if (_eventBonuses.ContainsKey(type))
        {
            _eventBonuses[type].Remove(source);
        }
    }
    
    
    #endregion
}