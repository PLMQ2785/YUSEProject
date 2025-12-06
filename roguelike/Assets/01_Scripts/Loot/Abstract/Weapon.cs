/*
 * [Weapon.cs]
 * [패키지 2] 플레이어 로직 - 무기 시스템
 * 공격형 장비의 기본 클래스입니다.
 */

using UnityEngine;

public abstract class Weapon : EquipmentBase
{
    #region Protected Fields
    protected float _currentCooldown = 0f;
    #endregion

    #region Public Properties
    public WeaponData WeaponData => _data as WeaponData;
    #endregion

    #region Unity LifeCycle
    protected virtual void Update()
    {
        // 초기화되지 않았으면 리턴
        if (_player == null || WeaponData == null)
        {
            return;
        }

        UpdateCooldown(Time.deltaTime);

        if (_currentCooldown <= 0f)
        {
            PerformAttack();
            _currentCooldown = CalculateCooldown();
        }
    }
    #endregion

    #region Public Methods
    public override void Initialize(PlayerManager player, EquipmentData data)
    {
        base.Initialize(player, data);
        _currentCooldown = 0f; // 시작 시 쿨타임 0
    }

    public virtual void UpdateCooldown(float deltaTime)
    {
        if (_currentCooldown > 0f)
        {
            _currentCooldown -= deltaTime;
        }
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// 플레이어 스탯을 반영하여 최종 데미지를 계산합니다.
    /// AttackDamageMult와 크리티컬 시스템을 적용합니다.
    /// </summary>
    /// <param name="baseDamage">기본 데미지</param>
    /// <param name="isCritical">크리티컬 히트 발생 여부</param>
    /// <returns>최종 계산된 데미지</returns>
    protected float CalculateDamage(float baseDamage, out bool isCritical)
    {
        // DEBUG: 메서드 호출 확인
        Debug.Log($"[CalculateDamage] Called with baseDamage: {baseDamage}");
        
        // 1. 공격력 배율 적용
        float damage = baseDamage * _player.Stats.AttackDamageMult;
        Debug.Log($"[CalculateDamage] After AttackDamageMult ({_player.Stats.AttackDamageMult}): {damage}");
        
        // 2. 크리티컬 판정
        float critRoll = Random.Range(0f, 100f);
        isCritical = critRoll < _player.Stats.CritChance;
        Debug.Log($"[CalculateDamage] CritChance: {_player.Stats.CritChance}%, Roll: {critRoll:F1}, IsCrit: {isCritical}");
        
        if (isCritical)
        {
            // 3. 크리티컬 데미지 배율 적용
            damage *= _player.Stats.CritDamageMult;
            Debug.Log($"[{WeaponData.EquipmentName}] Critical Hit! Damage: {damage:F1} (Base: {baseDamage:F1})");
        }
        
        return damage;
    }

    /// <summary>
    /// 플레이어 스탯을 반영하여 최종 쿨다운을 계산합니다.
    /// AttackSpeedMult와 CooldownMult를 적용합니다.
    /// </summary>
    /// <returns>최종 계산된 쿨다운 (초)</returns>
    protected float CalculateCooldown()
    {
        // 최종 쿨다운 = BaseCooldown × CooldownMult ÷ AttackSpeedMult
        // AttackSpeedMult가 높을수록 쿨다운 감소 (공격 속도 증가)
        // CooldownMult가 낮을수록 쿨다운 감소
        float cooldown = WeaponData.BaseCooldown * _player.Stats.CooldownMult / _player.Stats.AttackSpeedMult;
        
        // 최소 쿨다운 보장 (너무 빠른 공격 방지)
        return Mathf.Max(0.05f, cooldown);
    }
    #endregion

    #region Abstract Methods
    /// <summary>
    /// 실제 공격 로직을 구현합니다.
    /// 쿨타임이 0이 되면 Update에서 자동으로 호출됩니다.
    /// </summary>
    protected abstract void PerformAttack();
    #endregion
}
