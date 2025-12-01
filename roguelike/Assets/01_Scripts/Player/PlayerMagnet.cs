using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerMagnet : MonoBehaviour
{
    [Header("Magnet Settings")]
    [SerializeField] private float magnetRadius = 3f;   // 자석 범위
    [SerializeField] private LayerMask orbLayer;        // 구슬 레이어
    [SerializeField] private int maxTargetsPerFrame = 20;

    private PlayerManager _playerManager;
    private Collider2D[] _results;

    private void Awake()
    {
        _playerManager = GetComponent<PlayerManager>();
        _results = new Collider2D[maxTargetsPerFrame];
    }

    private void Update()
    {
        // 플레이어 위치 기준으로 구슬 감지
        Vector2 center = _playerManager.Player_Position; // or transform.position

        int count = Physics2D.OverlapCircleNonAlloc(
            center,
            magnetRadius,
            _results,
            orbLayer
        );

        for (int i = 0; i < count; i++)
        {
            Collider2D col = _results[i];
            if (col == null) continue;

            AcquireableObject acq = col.GetComponent<AcquireableObject>();
            if (acq != null)
            {
                acq.StartMoveTo(_playerManager);
            }

            _results[i] = null; // 다음 프레임을 위해 초기화
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
