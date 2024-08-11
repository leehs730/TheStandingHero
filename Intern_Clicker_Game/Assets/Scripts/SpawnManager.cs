using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int CurrentEnemyCount = 0;
    public GameObject[] Enemy;
    public GameObject instantEnemy;
    public Transform SpawnPoint;

    public static SpawnManager _instance;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (CurrentEnemyCount != 0)
        {
            return;
        }
        if(CurrentEnemyCount == 0)
        {
            int idx = Random.Range(0, Enemy.Length);
            GameObject enemy = Instantiate(Enemy[idx], SpawnPoint.position, Quaternion.identity);
            //GameObject enemy = Instantiate(instantEnemy, SpawnPoint.position, Quaternion.identity);
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            enemy.GetComponent<EnemyMove>().target = player;
            CurrentEnemyCount++;
        }
    }
}
