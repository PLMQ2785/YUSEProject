using UnityEngine;
using TMPro;

/// <summary>
/// 플레이어 위에 떠오르며 페이드 아웃되는 텍스트
/// 대시 쿨타임 알림 등에 사용
/// </summary>
public class FloatingText : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private float riseDuration = 1.5f;    // 총 지속 시간
    [SerializeField] private float riseSpeed = 1f;         // 상승 속도
    [SerializeField] private float fadeInDuration = 0.2f;  // 페이드인 시간
    [SerializeField] private float fadeOutStart = 0.5f;    // 페이드아웃 시작 (0~1 비율)
    
    private TextMeshPro _textMesh;
    private float _elapsedTime;
    private Color _originalColor;
    private Vector3 _startPosition;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();
        if (_textMesh == null)
        {
            _textMesh = GetComponentInChildren<TextMeshPro>();
        }
    }

    /// <summary>
    /// 텍스트 초기화 및 애니메이션 시작
    /// </summary>
    public void Initialize(string text, Vector3 startPosition)
    {
        if (_textMesh == null)
        {
            Debug.LogError("FloatingText: TextMeshPro component not found!");
            Destroy(gameObject);
            return;
        }
        
        _textMesh.text = text;
        _startPosition = startPosition;
        transform.position = startPosition;
        
        // 초기 투명도 0으로 설정
        _originalColor = _textMesh.color;
        Color transparent = _originalColor;
        transparent.a = 0f;
        _textMesh.color = transparent;
        
        _elapsedTime = 0f;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        // 상승 애니메이션
        transform.position = _startPosition + Vector3.up * (riseSpeed * _elapsedTime);
        
        // 알파값 계산
        float alpha;
        float progress = _elapsedTime / riseDuration;
        
        if (progress < fadeInDuration / riseDuration)
        {
            // 페이드인 구간
            alpha = Mathf.Lerp(0f, 1f, _elapsedTime / fadeInDuration);
        }
        else if (progress < fadeOutStart)
        {
            // 유지 구간
            alpha = 1f;
        }
        else
        {
            // 페이드아웃 구간
            float fadeOutProgress = (progress - fadeOutStart) / (1f - fadeOutStart);
            alpha = Mathf.Lerp(1f, 0f, fadeOutProgress);
        }
        
        // 알파값 적용
        Color newColor = _originalColor;
        newColor.a = alpha;
        _textMesh.color = newColor;
        
        // 애니메이션 종료
        if (_elapsedTime >= riseDuration)
        {
            Destroy(gameObject);
        }
    }
}
