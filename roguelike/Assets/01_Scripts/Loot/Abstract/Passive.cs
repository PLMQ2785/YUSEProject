/*
 * [Passive.cs]
 * [패키지 2] 플레이어 로직 - 패시브 시스템
 * 능력치 증가 등 패시브 효과를 담당하는 클래스입니다.
 */

using UnityEngine;

public class Passive : EquipmentBase
{
    #region Public Properties
    public PassiveData PassiveData => _data as PassiveData;
    #endregion

    #region Public Methods
    public override void Initialize(PlayerManager player, EquipmentData data)
    {
        base.Initialize(player, data);
        ApplyStatBonus();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        ApplyStatBonus(); // 레벨업 시 스탯 재적용 (누적 방식인지 재계산 방식인지에 따라 다름)
    }
    #endregion

    #region Unity LifeCycle
    /// <summary>
    /// GameObject 파괴 시 스탯 보너스를 제거합니다.
    /// 이를 통해 GameObject 생명주기와 효과 생명주기를 일치시킵니다.
    /// </summary>
    private void OnDestroy()
    {
        if (_player != null && PassiveData != null)
        {
            _player.RemovePassiveBonus(PassiveData.StatType, this);
            Debug.Log($"Removed Passive Bonus: {PassiveData.StatType} (Source: {PassiveData.EquipmentName})");
        }
    }
    #endregion

    #region Private Methods
    private void ApplyStatBonus()
    {
        if (PassiveData == null || _player == null) return;

        // PlayerManager를 통해 스탯 적용 (캡슐화 유지)
        float bonusValue = PassiveData.StatValue * _level;
        _player.AddPassiveBonus(PassiveData.StatType, this, bonusValue);
        
        Debug.Log($"Applied Passive Bonus: {PassiveData.StatType} + {bonusValue} (Source: {PassiveData.EquipmentName})");
    }
    #endregion
}
