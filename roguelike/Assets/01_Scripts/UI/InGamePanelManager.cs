/*
 * [InGamePanelManager.cs]
 * [패키지 4] 인게임 UI/UX
 * (더미 스크립트: Sprint 1~3에 걸쳐 구현)
 *
 * GameManager(묶음 1)가 컴파일 오류를 일으키지 않도록
 * 필수 함수들을 임시로 정의합니다. (SDS 3.2.3)
 */

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanelManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private RewardManager rewardManager; // 보상 UI를 위한 참조

    // (컨벤션 1-1) 
    // Sprint 1에서 UI 아티스트가 만든 프리팹을 이곳에 연결합니다.
    [Header("UI Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI pauseTimerText; // 일시정지패널 타이머 텍스트

    [Header("RewardPanel UI")]
    [SerializeField] private GameObject rewardPanel;
    [SerializeField] private Button[] rewardSlots; // 보상 슬롯 버튼
    [SerializeField] private Image[] rewardsIcon; // 보상 아이콘
    [SerializeField] private Text[] rewardsDescription; // 보상 설명 텍스트
    [SerializeField] private TextMeshProUGUI rerollCostText; // 리롤 비용 텍스트
    [SerializeField] private TextMeshProUGUI rerollCountText; // 리롤 횟수 텍스트
    [SerializeField] private TextMeshProUGUI skipExpRatio; // 스킵 시 경험치 보상 텍스트

    [Header("GameOver UI Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverTitleText; // 게임오버패널 제목 텍스트
    [SerializeField] private TextMeshProUGUI gameOverTimerText; // 게임오버패널 타이머 텍스트
    [SerializeField] private TextMeshProUGUI gameOverGoldText; // 게임오버패널 골드 텍스트
    [SerializeField] private TextMeshProUGUI gameOverKillCountText; // 게임오버패널 킬카운트 텍스트

    // [SerializeField] private GameObject gameClearPanel;

    // (Sprint 2)
    [SerializeField] private GameObject settingPanel;
    #endregion

    private void Start()
    {
        // RewardUI 이벤트 구독
        if (rewardManager == null)
        {
            Debug.LogError("[HUDManager] RewardManager is NULL");
        }
        else
        {
            rewardManager.OnRewardTextUIChanged += UpdateRewardTextUI;
            rewardManager.OnRewardUIChanged += UpdateRewardUI;
        }

    }

    private void OnDestroy()
    {
        if (rewardManager != null)
        {
            rewardManager.OnRewardTextUIChanged -= UpdateRewardTextUI;
            rewardManager.OnRewardUIChanged -= UpdateRewardUI;
        }
    }

    #region Public Methods
    /// <summary>
    /// (S2, D-2.a) GameManager가 호출할 더미 함수
    /// </summary>
    public void ShowPausePanel(bool show)
    {
        Debug.Log("InGamePanelManager: 일시정지 패널 " + (show ? "표시" : "숨김"));
        if (pausePanel != null)
        {
            pausePanel.SetActive(show);
        }
    }

    /// <summary>
    /// (S2, D-2.b) GameManager가 호출할 더미 함수
    /// </summary>
    public void ShowRewardPanel(bool show)
    {
        Debug.Log("InGamePanelManager: 보상 패널 " + (show ? "표시" : "숨김"));
        if (rewardPanel != null) 
        { 
            rewardPanel.SetActive(show);
        }
            
    }

    /// <summary>
    /// (S3, D-2.c) GameManager가 호출할 더미 함수
    /// </summary>
    public void ShowGameOverPanel(bool show, bool clear)
    {
        Debug.Log("InGamePanelManager: 게임 오버 패널 " + (show ? "표시" : "숨김") + "/클리어 여부 " + (clear));
        if (gameOverPanel != null)
        {
            UpdateGameOverPanel(clear);
          
            gameOverPanel.SetActive(show);
        }
           
    }

    /* ShowGameOverPanel에서 클리어 여부를 받아서 처리
    /// <summary>
    /// (S3, D-2.c) GameManager가 호출할 더미 함수
    /// </summary>
    public void ShowGameClearPanel(bool show)
    {
        Debug.Log("InGamePanelManager: 게임 클리어 패널 " + (show ? "표시" : "숨김"));
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(show);
        }

    }*/

    /// <summary>
    /// '메인메뉴' 버튼 클릭 시 호출
    /// </summary>
    public void OnClickMainMenu()
    {
        GameManager.Instance.GoToMainMenu();
    }

    /// <summary>
    /// '다시하기' 버튼 클릭 시 호출
    /// </summary>
    public void OnClickRestart()
    {
        GameManager.Instance.RestartGame();
    }

    /// <summary>
    /// '계속하기' 버튼 클릭 시 호출
    /// </summary>
    public void OnClickResume()
    {
        GameManager.Instance.ResumeGame();
    }

    /// <summary>
    /// '설정' 버튼 클릭 시 호출
    /// </summary>
    public void OnClickSetting()
    {
        if (settingPanel != null)
            settingPanel.SetActive(true);
    }
    #endregion

    #region Private Methods
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
        rerollCostText.color = (cost <= GameManager.Instance.Player.Gold) ? Color.white : Color.red;

        // 리롤 횟수 업데이트
        if (rerollCountText != null)
            rerollCountText.text = count.ToString();

        // 리롤 횟수 부족 시 빨간색으로 표시
        rerollCountText.color = (count > 0) ? Color.white : Color.red;

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

    /// <summary>
    /// 게임오버패널 업데이트 함수
    /// GameManager가 ShowGameOverPanel(bool show, bool clear)호출 시 clear 여부에 따라 업데이트
    /// </summary>
    private void UpdateGameOverPanel(bool clear)
    {
        if (!gameOverTitleText || !gameOverTimerText || !gameOverGoldText || !gameOverKillCountText) 
        {
            Debug.LogError("[InGamePanelManager] GameOverPanel's Text is NULL");
            return; 
        }

        // 게임오버패널 제목 텍스트
        gameOverTitleText.text = clear ? "클리어" : "죽었습니다..";

        // 게임오버패널 타이머 텍스트
        float time = GameManager.Instance.GameTime;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        gameOverTimerText.text = $"{minutes:00}:{seconds:00}";

        // 게임오버패널 골드 텍스트
        gameOverGoldText.text = GameManager.Instance.Player.Gold.ToString();

        // 게임오버패널 킬카운트 텍스트
        gameOverKillCountText.text = GameManager.Instance.Player.KillCount.ToString();
    }
    #endregion
}