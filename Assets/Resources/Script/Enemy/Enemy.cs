using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int         m_WayPointCount;      //�̵� ��� ����
    private Transform[] m_WayPoints;          //�̵� ��� ����
    private int         m_CurrentIndex = 0;   //���� ������Ʈ �ε���
    private EnemyMove   m_EnemyMove;          //������Ʈ �̵� ����


    private void Start()
    {
        
    }


    public void SetUp(Transform[] waypoints)
    {

        m_EnemyMove = GetComponent<EnemyMove>();


        // �̵� ��� ���� ����
        m_WayPointCount = waypoints.Length;
        this.m_WayPoints = new Transform[m_WayPointCount];
        this.m_WayPoints = waypoints;

        transform.position = waypoints[m_CurrentIndex].position;


        StartCoroutine(OnMove());

    }


    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            //ȸ��
            //transform.Rotate(Vector3.forward * 10);

            //��ǥ ��ġ�� ���� �ߴ��� ���� üũ, 0.02f ���� ���� ����ε� ���⼭ MoveSpeed�� ������ ������
            //�����ӿ� �ӵ��� ���� 0.02���� ũ�� �����̱� ������ ��θ� Ż���ϴ� ������Ʈ�� �������� �־
            //���� �� ���ִ°�
            if (Vector3.Distance(transform.position, m_WayPoints[m_CurrentIndex].position) < 0.02f * m_EnemyMove.MoveSpeed)
            {
                NextMoveTo();
            }


            yield return null;
        }

    }

    private void NextMoveTo()
    {


        //�̵� �ؾ��� wayPoints�� �����ִٸ�
        if(m_CurrentIndex < m_WayPointCount - 1)
        {
            //���� ��ġ�� ��Ȯ�ϰ� ��ǥ��ġ�� ���� (�ణ�� ��� �༮���� ����Ʈ �ڸ���)
            transform.position = m_WayPoints[m_CurrentIndex].position;

            //�̵� �ؾ��� ����Ʈ�� �ε��� �ѱ��
            m_CurrentIndex++;


            Vector3 dir = (m_WayPoints[m_CurrentIndex].position - transform.position).normalized;
            m_EnemyMove.MoveTo(dir);

        }

        else
        {
            m_CurrentIndex = 0;
            //Destroy(gameObject);
        }


    }


}
