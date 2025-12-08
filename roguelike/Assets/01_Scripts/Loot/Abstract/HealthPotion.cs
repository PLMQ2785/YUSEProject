using UnityEngine;

/// <summary>
/// 회복 포션: 최대 HP의 20%를 회복하는 소모성 아이템
/// </summary>
public class HealthPotion : Item
{
    [Header("Health Potion Settings")]
    [SerializeField]
    [Range(0f, 1f)]
    private float healPercentage = 0.2f; // 회복 비율 (20%)

    /// <summary>
    /// 포션 사용 시 실제 회복 효과를 적용
    /// </summary>
    public override bool Activate()
    {
        // 기본 아이템 사용 로직 확인 (쿨다운, 개수 체크 등)
        if (!base.Activate())
        {
            return false;
        }

        // 회복 로직 실행
        ApplyHealingEffect();
        
        return true;
    }

    /// <summary>
    /// 실제 회복 효과를 적용합니다.
    /// </summary>
    private void ApplyHealingEffect()
    {
        // PlayerManager에서 현재 HP와 최대 HP 가져오기
        PlayerManager player = GameManager.Instance.Player;
        
        if (player == null)
        {
            Debug.LogWarning("HealthPotion: PlayerManager를 찾을 수 없습니다.");
            return;
        }

        float maxHp = player.Stats.MaxHp;
        float healAmount = maxHp * healPercentage;
        
        // PlayerManager의 Heal 메서드 사용
        player.Heal(healAmount);
    }
}
