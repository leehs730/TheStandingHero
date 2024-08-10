using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        enemyInfo = GetComponent<EnemyInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemyInfo.Speed * Time.deltaTime);
    }
}
