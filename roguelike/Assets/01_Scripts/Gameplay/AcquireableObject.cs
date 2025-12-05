using UnityEngine;

public abstract class AcquireableObject : MonoBehaviour
{
    
    public Vector2 Position =>transform.position;
    protected PlayerManager currentTarget = null;  
    private bool _isMovingToPlayer = false;        

    #region life Cycle

    private void Update()
    {
        if (_isMovingToPlayer && currentTarget != null)
        {
            MoveToPlayer(currentTarget);
        }
    }

    #endregion



    #region public method
    [Header("Settings")]
    public float moveSpeed = 3.0f; //날라가는 속도

    public void StartMoveTo(PlayerManager target)
    {
        currentTarget = target;
        _isMovingToPlayer = true;
    }

    public void StopMove()
    {
        _isMovingToPlayer = false;
        currentTarget = null;
    }
    
    public void MoveToPlayer(PlayerManager target)
    {
        if (target == null)
        {
            StopMove();
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.Player_Position, moveSpeed*Time.deltaTime); //플레이어쪽으로

        // 거리가 가까우면 획득
        if(Vector2.Distance(transform.position, target.Player_Position) <0.5f)
        {
            OnAcquire(target);
        }
    }

    public abstract void OnAcquire(PlayerManager player);

    #endregion
}
