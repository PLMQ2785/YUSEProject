using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject questInfoPanel;
    [SerializeField] private PlayerManager player;
    [SerializeField] private GameManager gameManager;
    #endregion

    private void Start()
    {
        player.OnHpChanged += UpdateHpBar;
    }


    private void UpdateHpBar(float currentHp, float maxHp)
    {
        slider.value = currentHp / maxHp;
    }

    private void UpdateExpBar(float currentExp, float maxExp) 
    {
        slider.value = currentExp / maxExp;
    }

    private void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        text.text = $"{minutes:D2}:{seconds:D2}";
    }

    private void UpdateGold(int amount)
    {
        text.text = amount.ToString();
    }

    private void UpdateKillCount(int count)
    {
        text.text = count.ToString();
    }

    private void ShowBossHpBar(float currentHp, float maxHp)
    {
        slider.enabled = true;
    }

    private void ToggleQuestInfo(bool show, string description) 
    {
    
    }
}
