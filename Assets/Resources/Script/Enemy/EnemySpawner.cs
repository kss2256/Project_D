using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField]
    private GameObject      enemyPrefab;        //적 프리팹
    [SerializeField]
    private float           spawnTime;          //적 생성 주기
    [SerializeField]
    private Transform[]     wayPoints;          // 현재 스테이지 이동 경로

    

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
