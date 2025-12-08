using UnityEngine;

public class TreasureBox :AcquireableObject
{

    private bool _isAcquired = false;


    private void Start()
    {
        moveSpeed = 5.0f;
    }


    public override void OnAcquire(PlayerManager player)
    {
        if(_isAcquired) return;
        _isAcquired = true;

        Debug.Log("보물상자 획득, 보상 창 열기");


        if (GameManager.Instance != null)
        {
            GameManager.Instance.TriggerRewardProcess();
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 이미 획득했거나 플레이어가 아니면 무시
        if (_isAcquired) return;

        // 충돌한 대상이 플레이어인지 확인 (태그나 컴포넌트로 확인)
        if (collision.CompareTag("Player"))
        {
            PlayerManager player = collision.GetComponent<PlayerManager>();
            if (player != null)
            {
                OnAcquire(player);
            }
        }
    }
}
