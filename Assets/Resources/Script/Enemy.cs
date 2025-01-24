using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int         wayPointCount;      //�̵� ��� ����
    private Transform[] wayPoints;          //�̵� ��� ����
    private int         currentIndex = 0;   //���� ������Ʈ �ε���
    private EnemyMove   enemyMove;          //������Ʈ �̵� ����


    private void Start()
    {
        InputManager input = Engine.Input;
    }


    public void SetUp(Transform[] waypoints)
    {

        enemyMove = GetComponent<EnemyMove>();


        // �̵� ��� ���� ����
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
            //ȸ��
            transform.Rotate(Vector3.forward * 10);

            //��ǥ ��ġ�� ���� �ߴ��� ���� üũ, 0.02f ���� ���� ����ε� ���⼭ MoveSpeed�� ������ ������
            //�����ӿ� �ӵ��� ���� 0.02���� ũ�� �����̱� ������ ��θ� Ż���ϴ� ������Ʈ�� �������� �־
            //���� �� ���ִ°�
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * enemyMove.MoveSpeed)
            {
                NextMoveTo();
            }


            yield return null;
        }

    }

    private void NextMoveTo()
    {


        //�̵� �ؾ��� wayPoints�� �����ִٸ�
        if(currentIndex < wayPointCount - 1)
        {
            //���� ��ġ�� ��Ȯ�ϰ� ��ǥ��ġ�� ���� (�ణ�� ��� �༮���� ����Ʈ �ڸ���)
            transform.position = wayPoints[currentIndex].position;

            //�̵� �ؾ��� ����Ʈ�� �ε��� �ѱ��
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
