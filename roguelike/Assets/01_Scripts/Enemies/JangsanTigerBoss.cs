using System.Collections;
using UnityEngine;

public class JangsanTigerBoss : BossMonster
{
    [Header("Pattern Settings")]
    [SerializeField] private float patternInterval = 5f; // 패턴 사이 간격
    [SerializeField] private float patternWarningTime = 1f; // 패턴 전조 시간

    [Header("Pattern 1: Teleport Dash")]
    [SerializeField] private float teleportDashSpeed = 10f; // 순간이동 후 돌진 속도
    [SerializeField] private float teleportDashDistance = 6f; // 돌진 거리
    [SerializeField] private float fadeOutDuration = 1f; // 페이드아웃 시간
    [SerializeField] private float fadeInDuration = 0.2f; // 페이드인 시간

    [Header("Pattern 2: Cross & X Barrage")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 7f;
    [SerializeField] private float projectileSize = 1.0f;
    [SerializeField] private float projectileDamage = 5f;
    [SerializeField] private int barrageCount = 4; // 발사 횟수
    [SerializeField] private float barrageInterval = 0.3f; // 발사 간격

    [Header("Pattern 3: Inertia Chase")]
    [SerializeField] private float inertiaChaseMaxSpeed = 12f; // 최대 속도
    [SerializeField] private float inertiaChaseAcceleration = 15f; // 가속도
    [SerializeField] private float inertiaChaseRotationSpeed = 2f; // 회전 속도 (관성 표현)
    [SerializeField] private float inertiaChaseDuration = 3.5f; // 추격 지속 시간

    private bool _isPatternActive = false;
    private float _patternTimer = 0f;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _currentVelocity = Vector2.zero; // 관성 추격용 속도 벡터

    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        _patternTimer = patternInterval;
    }

    protected override void Update()
    {
        if (_isPatternActive) return;

        // 평소에는 플레이어 추적
        base.Update();

        _patternTimer -= Time.deltaTime;
        if (_patternTimer <= 0)
        {
            StartCoroutine(ExecuteRandomPattern());
        }
    }

    private IEnumerator ExecuteRandomPattern()
    {
        _isPatternActive = true;

        // 패턴 랜덤 선택 (3가지)
        int patternIndex = Random.Range(0, 3);

        // 패턴 시작 전 멈춤
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        switch (patternIndex)
        {
            case 0:
                yield return StartCoroutine(Pattern_TeleportDash());
                break;
            case 1:
                yield return StartCoroutine(Pattern_CrossXBarrage());
                break;
            case 2:
                yield return StartCoroutine(Pattern_InertiaChase());
                break;
        }

        _isPatternActive = false;
        _patternTimer = patternInterval;
    }

    // 패턴 1: 순간이동 돌진
    private IEnumerator Pattern_TeleportDash()
    {
        Debug.Log("JangsanTiger: Teleport Dash Pattern Start");

        // 1. 페이드 아웃 
        yield return StartCoroutine(FadeOut(fadeOutDuration));

        // 2. 플레이어 뒤로 순간이동
        if (_target != null)
        {
            TeleportBehindPlayer();
        }

        // 3. 페이드 인 
        yield return StartCoroutine(FadeIn(fadeInDuration));

        // 4. 플레이어를 향해 돌진
        if (_target != null)
        {
            Vector2 dashDirection = (_target.position - transform.position).normalized;
            Vector2 startPos = transform.position;
            Vector2 dashTargetPos = startPos + dashDirection * teleportDashDistance;

            float dashDuration = teleportDashDistance / teleportDashSpeed;
            float elapsedTime = 0f;

            while (elapsedTime < dashDuration)
            {
                transform.position = Vector2.Lerp(startPos, dashTargetPos, elapsedTime / dashDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = dashTargetPos;
        }
    }

    // 패턴 2: 십자/X 투사체
    private IEnumerator Pattern_CrossXBarrage()
    {
        Debug.Log("JangsanTiger: Cross & X Barrage Pattern Start");

        // 전조
        yield return new WaitForSeconds(patternWarningTime);

        // 반복: 십자 -> X -> 십자 -> X
        for (int i = 0; i < barrageCount; i++)
        {
            if (i % 2 == 0)
            {
                // 홀수 회차: 십자(+)
                FireProjectilesInCross();
            }
            else
            {
                // 짝수 회차: X(×)
                FireProjectilesInX();
            }

            yield return new WaitForSeconds(barrageInterval);
        }
    }

    // 패턴 3: 관성 추격
    private IEnumerator Pattern_InertiaChase()
    {
        Debug.Log("JangsanTiger: Inertia Chase Pattern Start");

        // 1. 1초 정지 (전조)
        yield return new WaitForSeconds(patternWarningTime);

        // 2. 관성 추격 시작
        _currentVelocity = Vector2.zero;
        float elapsedTime = 0f;

        while (elapsedTime < inertiaChaseDuration)
        {
            if (_target != null)
            {
                // 목표 방향 계산
                Vector2 targetDirection = (_target.position - transform.position).normalized;

                // 현재 속도 방향과 목표 방향을 보간 (관성 효과)
                Vector2 desiredVelocity = targetDirection * inertiaChaseMaxSpeed;
                _currentVelocity = Vector2.Lerp(_currentVelocity, desiredVelocity, 
                    inertiaChaseRotationSpeed * Time.deltaTime);

                // 최대 속도 제한
                if (_currentVelocity.magnitude > inertiaChaseMaxSpeed)
                {
                    _currentVelocity = _currentVelocity.normalized * inertiaChaseMaxSpeed;
                }

                // 이동
                transform.position = (Vector2)transform.position + _currentVelocity * Time.deltaTime;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 3. 급감속
        float decelerationTime = 0.5f;
        float decelerationElapsed = 0f;

        while (decelerationElapsed < decelerationTime)
        {
            _currentVelocity = Vector2.Lerp(_currentVelocity, Vector2.zero, 
                decelerationElapsed / decelerationTime);
            transform.position = (Vector2)transform.position + _currentVelocity * Time.deltaTime;

            decelerationElapsed += Time.deltaTime;
            yield return null;
        }

        _currentVelocity = Vector2.zero;
    }

    // === 헬퍼 메서드 ===

    private IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        Color originalColor = _spriteRenderer.color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            _spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;
        Color originalColor = _spriteRenderer.color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            _spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }

    private void TeleportBehindPlayer()
    {
        if (_target == null) return;

        // 플레이어의 반대 방향으로 2.5 유닛 거리
        PlayerManager player = _target.GetComponent<PlayerManager>();
        Vector2 playerFacingDirection = player != null ? player.FacingDirection : Vector2.right;
        
        Vector2 behindPosition = (Vector2)_target.position - playerFacingDirection * 2.5f;
        transform.position = behindPosition;
    }

    private void FireProjectilesInCross()
    {
        // 상하좌우 
        FireProjectile(Vector2.up);
        FireProjectile(Vector2.down);
        FireProjectile(Vector2.left);
        FireProjectile(Vector2.right);
    }

    private void FireProjectilesInX()
    {
        // 대각선
        FireProjectile(new Vector2(1, 1).normalized);
        FireProjectile(new Vector2(1, -1).normalized);
        FireProjectile(new Vector2(-1, 1).normalized);
        FireProjectile(new Vector2(-1, -1).normalized);
    }

    private void FireProjectile(Vector2 direction)
    {
        if (projectilePrefab == null) return;

        GameObject projObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile2 proj = projObj.GetComponent<Projectile2>();
        if (proj != null)
        {
            proj.SetSize(projectileSize);
            proj.SetSpeed(projectileSpeed);
            proj.SetDamage(projectileDamage);
            proj.Init(direction);
        }
    }
}
