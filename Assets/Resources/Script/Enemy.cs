using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int         wayPointCount;      //이동 경로 개수
    private Transform[] wayPoints;          //이동 경로 정보
    private int         currentIndex = 0;   //현재 오브젝트 인덱스
    private EnemyMove   enemyMove;          //오브젝트 이동 제어


    private void Start()
    {
        InputManager input = Engine.Input;
    }


    public void SetUp(Transform[] waypoints)
    {

        enemyMove = GetComponent<EnemyMove>();


        // 이동 경로 정보 설정
        wayPointCount = waypoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = waypoints;

        transform.position = waypoints[currentIndex].position;


        StartCoroutine(OnMove());

    }


    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            //회전
            transform.Rotate(Vector3.forward * 10);

            //목표 위치에 도달 했는지 조건 체크, 0.02f 보다 작을 경우인데 여기서 MoveSpeed를 곱해준 이유는
            //프레임에 속도가 빨라서 0.02보다 크게 움직이기 떄문에 경로를 탈주하는 오브젝트가 있을수도 있어서
            //방지 차 해주는것
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * enemyMove.MoveSpeed)
            {
                NextMoveTo();
            }


            yield return null;
        }

    }

    private void NextMoveTo()
    {


        //이동 해야할 wayPoints가 남아있다면
        if(currentIndex < wayPointCount - 1)
        {
            //적의 위치를 정확하게 목표위치로 설정 (약간의 벗어난 녀석들을 포인트 자리로)
            transform.position = wayPoints[currentIndex].position;

            //이동 해야할 포인트로 인덱스 넘기기
            currentIndex++;


            Vector3 dir = (wayPoints[currentIndex].position - transform.position).normalized;
            enemyMove.MoveTo(dir);

        }

        else
        {
            Destroy(gameObject);
        }


    }


}
