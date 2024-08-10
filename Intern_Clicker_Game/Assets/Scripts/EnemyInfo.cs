using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public string name;
    public int Hp = 100;
    public int CurrentHp;
    public int Grade;
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

    //public IEnumerator TakeDamageWithCoroutine(int dam, float time)
    //{
    //    if (CurrentHp <= 0)
    //    {
    //        yield return null;
    //    }
    //    CurrentHp -= dam;
    //    yield return new WaitForSeconds(time);
    //    Debug.Log("플레이어 공격 받음. 남은 체력 : " + CurrentHp);
        
    //}

    public void EnemyDead()
    {
        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Death");
        }
    }

    //public void TakeDamage(int damage)
    //{
    //    if(CurrentHp <= 0)
    //    {
    //        return;
    //    }
    //    TakeDamageWithCoroutine (damage, 1f);
    //    //if (CurrentHp <= 0) 
    //    //{ 
    //    //    Destroy(gameObject);
    //    //    Debug.Log("Enemy Death");
    //    //}
    //}
}
