using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
public static EventManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private PlayerManager playerManager; // 인스펙터 할당 해야 합니다!

    [Header("Event Settings")]
    [SerializeField] private List<GameEventData> possibleEvents;
    [SerializeField] private float minEventInterval = 60f;
    [SerializeField] private float maxEventInterval = 120f;

    private float _timer;
    private float _nextEventTime;
    private GameEventData _currentEvent;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SetNextEventTime();
        
        // PlayerManager check
        if (playerManager == null)
        {
            Debug.Log("PlayerManager NULL!");
            // playerManager = FindAnyObjectByType<PlayerManager>();
        }
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing)
        {
            return;
        }
        
        if (_currentEvent != null)
        {
            return; // 이미 이벤트 중이면 패스
        }

        _timer += Time.deltaTime;

        if (_timer >= _nextEventTime)
        {
            TriggerRandomEvent();
        }
    }

    private void SetNextEventTime()
    {
        _timer = 0f;
        _nextEventTime = Random.Range(minEventInterval, maxEventInterval);
    }

    public void TriggerRandomEvent()
    {
        if (possibleEvents.Count == 0) return;
        int idx = Random.Range(0, possibleEvents.Count);
        StartEvent(possibleEvents[idx]);
    }

    public void StartEvent(GameEventData eventData)
    {
        StartCoroutine(ProcessEventRoutine(eventData));
    }

    private IEnumerator ProcessEventRoutine(GameEventData eventData)
    {
        _currentEvent = eventData;
        Debug.Log($"[EVENT START] {eventData.notificationMessage}");
        // 나중에 HUDManager.Instance.ShowNotice(eventData.notificationMessage); 추가

        // 1. 플레이어에게 스탯 적용
        if (playerManager != null)
        {
            playerManager.ApplyEventModifiers(eventData, eventData.statModifiers);
        }

        // 2. 지속 시간 대기
        float duration = eventData.duration;
        while (duration > 0)
        {
            if (GameManager.Instance.CurrentState == GameState.Playing)
            {
                duration -= Time.deltaTime;
            }
            yield return null;
        }

        // 3. 이벤트 종료
        EndEvent(eventData);
    }

    private void EndEvent(GameEventData eventData)
    {
        if (_currentEvent == null) return;
        Debug.Log($"[EVENT END] {_currentEvent.eventName} 종료");

        // 1. 플레이어 스탯 원상복구
        if (playerManager != null)
        {
            playerManager.RemoveEventModifiers(eventData, _currentEvent.statModifiers);
        }

        _currentEvent = null;
        SetNextEventTime();
    }
}
