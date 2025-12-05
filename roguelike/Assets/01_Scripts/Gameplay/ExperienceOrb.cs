using UnityEngine;

public class ExperienceOrb : AcquireableObject
{
    [SerializeField] private int expAmount = 10;

    // 이 구슬이 어떤 프리팹에서 나왔는지 기억해두기 위한 필드
    private GameObject _prefabForPool;

    /// <summary>
    /// 몬스터가 풀에서 꺼낸 직후 한 번 호출해 줄 초기화 메서드
    /// </summary>
    public void Init(GameObject prefab)
    {
        _prefabForPool = prefab;
    }

    public override void OnAcquire(PlayerManager player)
    {
        // 경험치 지급
        player.GainExp(expAmount);

        // 자석 이동 멈추기 (AcquireableObject 쪽에 구현되어 있다고 가정)
        StopMove();

        // 풀매니저 있으면 풀로 반환
        if (PoolManager.Instance != null && _prefabForPool != null)
        {
            PoolManager.Instance.ReturnToPool(gameObject, _prefabForPool);
        }
        else
        {
            // 혹시나 정보가 없으면 안전하게 파괴
            Destroy(gameObject);
        }
    }
}
