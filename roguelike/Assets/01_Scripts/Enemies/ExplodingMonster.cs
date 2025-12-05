using UnityEngine;
using System.Collections;

/// <summary>
/// 죽을 때 일정 시간 후 주위에 데미지를 주는 몬스터
/// </summary>
public class ExplodingMonster : Monster
{
    #region Serialized Fields
    
    [Header("Explosion Settings")]
    [SerializeField] private float explosionDelay = 2f; // 폭발까지 걸리는 시간
    [SerializeField] private float explosionRange = 3f; // 폭발 범위
    [SerializeField] private float explosionDamage = 20f; // 폭발 데미지
    
    [Header("Visual Settings")]
    [SerializeField] private Color warningColor = new Color(1f, 0.5f, 0f, 0.3f); // 주황색 반투명
    [SerializeField] private Color explosionColor = new Color(1f, 0f, 0f, 0.5f); // 빨간색 반투명
    
    #endregion
    
    #region Private Fields
    
    private GameObject _explosionIndicator; // 폭발 범위 표시 오브젝트
    private SpriteRenderer _indicatorRenderer;
    private bool _isExploding = false; // 폭발 중인지 체크
    
    #endregion
    
    #region Unity Lifecycle
    
    protected override void Awake()
    {
        base.Awake();
        CreateExplosionIndicator();
    }
    
    protected override void Start()
    {
        base.Start();
        
        // 시작할 때는 폭발 표시기를 숨김
        if (_explosionIndicator != null)
        {
            _explosionIndicator.SetActive(false);
        }
    }
    
    #endregion
    
    #region Override Methods
    
    public override void Move(Vector2 targetPosition)
    {
        // 기본 이동 로직 (플레이어를 향해 이동)
        if (!_isExploding)
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }
    
    public override void Die()
    {
        // 이미 폭발 중이면 중복 실행 방지
        if (_isExploding)
            return;
        
        _isExploding = true;
        
        // 몬스터 이동 정지 및 충돌 비활성화
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        
        // 폭발 시퀀스 시작
        StartCoroutine(ExplosionSequence());
    }
    
    #endregion
    
    #region Private Methods
    
    /// <summary>
    /// 폭발 범위를 나타내는 원형 표시기 생성
    /// </summary>
    private void CreateExplosionIndicator()
    {
        // 자식 오브젝트로 원형 표시기 생성
        _explosionIndicator = new GameObject("ExplosionIndicator");
        _explosionIndicator.transform.SetParent(transform);
        _explosionIndicator.transform.localPosition = Vector3.zero;
        
        // SpriteRenderer 추가
        _indicatorRenderer = _explosionIndicator.AddComponent<SpriteRenderer>();
        
        // 원형 스프라이트 생성
        _indicatorRenderer.sprite = CreateCircleSprite(100);
        _indicatorRenderer.sortingOrder = 1; // 배경보다 위에 표시
        
        // 초기에는 비활성화
        _explosionIndicator.SetActive(false);
    }
    
    /// <summary>
    /// 원형 스프라이트 생성
    /// </summary>
    private Sprite CreateCircleSprite(int resolution)
    {
        Texture2D texture = new Texture2D(resolution, resolution);
        Color[] pixels = new Color[resolution * resolution];
        
        Vector2 center = new Vector2(resolution / 2f, resolution / 2f);
        float radius = resolution / 4f;
        
        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                Vector2 pos = new Vector2(x, y);
                float distance = Vector2.Distance(pos, center);
                
                // 원 안쪽이면 색상 적용, 바깥쪽이면 투명
                if (distance <= radius)
                {
                    pixels[y * resolution + x] = Color.white;
                }
                else
                {
                    pixels[y * resolution + x] = Color.clear;
                }
            }
        }
        
        texture.SetPixels(pixels);
        texture.Apply();
        
        return Sprite.Create(
            texture,
            new Rect(0, 0, resolution, resolution),
            new Vector2(0.5f, 0.5f),
            resolution / 2f // pixels per unit
        );
    }
    
    /// <summary>
    /// 폭발 시퀀스: 경고 표시 -> 폭발
    /// </summary>
    private IEnumerator ExplosionSequence()
    {
        // 1. 폭발 범위 표시기 활성화
        if (_explosionIndicator != null)
        {
            _explosionIndicator.SetActive(true);
            _indicatorRenderer.color = warningColor;
            
            // 폭발 범위에 맞게 크기 조정
            float scale = explosionRange * 2f;
            _explosionIndicator.transform.localScale = new Vector3(scale, scale, 1f);
        }
        
        // 2. 몬스터 스프라이트를 점멸시켜서 경고
        float elapsedTime = 0f;
        float blinkInterval = 0.2f;
        bool isVisible = true;
        
        while (elapsedTime < explosionDelay)
        {
            // 점멸 효과
            if (_spriteRenderer != null)
            {
                Color color = _spriteRenderer.color;
                color.a = isVisible ? 1f : 0.3f;
                _spriteRenderer.color = color;
                isVisible = !isVisible;
            }
            
            // 표시기 색상을 점점 빨갛게
            if (_indicatorRenderer != null)
            {
                float t = elapsedTime / explosionDelay;
                _indicatorRenderer.color = Color.Lerp(warningColor, explosionColor, t);
            }
            
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        
        // 3. 폭발 실행
        Explode();
        
        // 4. 폭발 이펙트 표시 (짧게)
        if (_indicatorRenderer != null)
        {
            _indicatorRenderer.color = explosionColor;
        }
        
        yield return new WaitForSeconds(0.2f);
        
        // 5. 정리 및 풀로 반환
        CleanupAndReturn();
    }
    
    /// <summary>
    /// 실제 폭발 로직: 범위 내 플레이어에게 데미지
    /// </summary>
    private void Explode()
    {
        // 폭발 범위 내의 모든 콜라이더 검색
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        
        foreach (var hitCollider in hitColliders)
        {
            // 플레이어인지 확인
            PlayerManager player = hitCollider.GetComponent<PlayerManager>();
            if (player != null)
            {
                // 폭발 데미지 적용
                player.TakeDamage(explosionDamage, false);
            }
        }
    }
    
    /// <summary>
    /// 폭발 후 정리 및 오브젝트 풀로 반환
    /// </summary>
    private void CleanupAndReturn()
    {
        // 상태 초기화
        _isExploding = false;
        
        // 폭발 표시기 숨김
        if (_explosionIndicator != null)
        {
            _explosionIndicator.SetActive(false);
        }
        
        // 콜라이더 다시 활성화
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = true;
        }
        
        // 스프라이트 투명도 복구
        if (_spriteRenderer != null)
        {
            Color color = _spriteRenderer.color;
            color.a = 1f;
            _spriteRenderer.color = color;
        }
        
        // 기본 Monster 클래스의 Die 로직 실행 (보상 드롭, 풀 반환 등)
        // 단, 중복 실행을 막기 위해 콜백만 호출
        DropExpOrb();
        UpGold(1);
        UpKillCount(1);
        unlocked = true;
        
        if (_returnToPoolAction != null)
        {
            _returnToPoolAction.Invoke(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    #endregion
    
    #region Gizmos
    
    /// <summary>
    /// Scene 뷰에서 폭발 범위 표시 (디버깅용)
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, explosionRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
    
    #endregion
}
