using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public string Name;
    public int Hp = 100;
    public int CurrentHp;
    public string Grade;
    public float Speed = 3f;
    public Animator EnemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = Hp;
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHp <= 0)
        {
            EnemyDead();
        }
        else
            CurrentHp -= damage;
    }



    public void EnemyDead()
    {
        if (CurrentHp <= 0)
        {
            SpawnManager._instance.CurrentEnemyCount--;
            Destroy(gameObject);
            Debug.Log("Enemy Death");
        }
    }

}
