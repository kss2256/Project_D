using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField]
    private GameObject      enemyPrefab;        //�� ������
    [SerializeField]
    private float           spawnTime;          //�� ���� �ֱ�
    [SerializeField]
    private Transform[]     wayPoints;          // ���� �������� �̵� ���

    

    private void Awake()
    {

        StartCoroutine(SpawnerEnemy());
    }


    private IEnumerator SpawnerEnemy()
    {
        while (true)
        {

            GameObject clone = Engine.Resource.Instantiate("Prefabs\\Enemy\\Enemy_1", this.transform);

            //GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.SetUp(wayPoints);


            yield return new WaitForSeconds(spawnTime);
        }

     

    }


}
