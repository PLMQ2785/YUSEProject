using UnityEngine;

/// <summary>
/// 몬스터가 플레이어로부터 일정 거리 이상 벗어나면 플레이어 주변으로 재배치하는 컴포넌트
/// Update() 기반 거리 체크 방식으로 100% 안정적인 재배치 보장
/// 플레이어 이동 방향을 고려하여 진행 방향 앞쪽에 재배치
/// </summary>
public class EnemyReposition : MonoBehaviour
{
    [Header("Reposition Settings")]
    [SerializeField] private float maxDistanceFromPlayer = 20f;  // 이 거리를 벗어나면 재배치
    [SerializeField] private float spawnDistance = 20f;          // 재배치 시 플레이어로부터의 거리
    [SerializeField] private float randomOffsetRange = 3f;       // 몬스터 겹침 방지용 랜덤 오프셋
    [SerializeField] private float forwardAngleRange = 120f;     // 진행 방향 기준 스폰 범위 (좌우 각도)

    private Collider2D _collider;
    private float _maxDistanceSqr;  // sqrMagnitude 비교용 (성능 최적화)

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _maxDistanceSqr = maxDistanceFromPlayer * maxDistanceFromPlayer;
    }

    private void Update()
    {
        // GameManager나 Player가 없으면 스킵
        if (GameManager.Instance == null || GameManager.Instance.Player == null)
            return;

        // 죽은 몹은 스킵 (콜라이더 비활성화 상태)
        if (_collider != null && !_collider.enabled)
            return;

        // 플레이어가 대시 중일 때는 재배치 방지
        if (GameManager.Instance.Player.IsDashing)
            return;

        // 거리 체크 (sqrMagnitude로 sqrt 연산 생략)
        Vector3 playerPos = GameManager.Instance.Player.Player_Position;
        Vector3 offset = transform.position - playerPos;
        float distanceSqr = offset.x * offset.x + offset.y * offset.y;

        // 최대 거리를 벗어났으면 재배치
        if (distanceSqr > _maxDistanceSqr)
        {
            Reposition(playerPos);
        }
    }

    /// <summary>
    /// 몬스터를 플레이어 주변의 새로운 위치로 재배치
    /// 플레이어의 이동 방향 앞쪽에 스폰하여 자연스러운 재배치
    /// </summary>
    private void Reposition(Vector3 playerPos)
    {
        // 플레이어의 이동 방향 가져오기
        Vector2 playerFacing = GameManager.Instance.Player.FacingDirection;
        
        // 이동 방향의 각도 계산
        float baseAngle = Mathf.Atan2(playerFacing.y, playerFacing.x) * Mathf.Rad2Deg;
        
        // 진행 방향 기준으로 좌우 forwardAngleRange/2 범위 내에서 랜덤 각도 선택
        // 예: forwardAngleRange = 120도면, 진행방향 기준 -60도 ~ +60도 범위
        float halfRange = forwardAngleRange / 2f;
        float randomAngle = baseAngle + Random.Range(-halfRange, halfRange);
        float randomAngleRad = randomAngle * Mathf.Deg2Rad;
        
        Vector3 spawnDir = new Vector3(Mathf.Cos(randomAngleRad), Mathf.Sin(randomAngleRad), 0f);

        // 기본 스폰 위치
        Vector3 newPosition = playerPos + (spawnDir * spawnDistance);

        // 몬스터 겹침 방지를 위한 랜덤 오프셋
        Vector3 randomOffset = new Vector3(
            Random.Range(-randomOffsetRange, randomOffsetRange),
            Random.Range(-randomOffsetRange, randomOffsetRange),
            0f
        );

        // 최종 위치 적용
        transform.position = newPosition + randomOffset;
    }
}
