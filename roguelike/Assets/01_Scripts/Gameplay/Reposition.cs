using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    [SerializeField]
    private float chunkSize = 40f;


    private void Update()
    {
        if (GameManager.Instance == null)
        {
            // Debug.Log("GameManager가 아직 준비되지 않았습니다.");
            return;
        }

        // 🚨 2단계: PlayerManager가 Null인지 확인
        if (GameManager.Instance.Player == null)
        {
            // Debug.Log("PlayerManager가 아직 초기화되지 않았습니다.");
            return;
        }

        // 3단계: 게임 상태 확인 (Playing일 때만 맵을 움직여야 함)
        if (GameManager.Instance.CurrentState != GameState.Playing)
        {
            return;
        }


        Vector3 playerPos = GameManager.Instance.Player.Player_Position;
        Vector3 myPos = transform.position;
    

        Vector3 _distance = playerPos - myPos;

        float threshold = chunkSize * 1.5f;


        if(Mathf.Abs(_distance.x)>threshold || Mathf.Abs(_distance.y)>threshold)
        {
            RepositionMapChucnk(_distance);
        }


    }


    private void RepositionMapChucnk(Vector3 distance)
    {
        const float CHUNK_SIZE = 40F;
        
        Vector3 newPosition = transform.position;

        float directionX = Mathf.Sign(distance.x);
        float directionY = Mathf.Sign(distance.y);

        const float MOVE_DISTANCE = CHUNK_SIZE * 3f;
        // x축 재배치 판단
        // 플레이어와의 x축 거리가 청크 크기(40)보다 클 경우
        if(Mathf.Abs(distance.x) >CHUNK_SIZE*1.5f)
        {

            newPosition.x += directionX * MOVE_DISTANCE;
        }

        //y축 재배치 판단
        if(Mathf.Abs(distance.y)> CHUNK_SIZE * 1.5f)
        {
            newPosition.y += directionY * MOVE_DISTANCE;
        }


        transform.position = newPosition;
    }
}
