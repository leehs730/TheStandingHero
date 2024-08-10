using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;
    public Vector2 boxSize;
    public Vector3 pos;
    public EnemyInfo enemyInfo;
    public GameObject enemy;

    public bool isAttack = false;

    public float delaytime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //pos = transform.position + new Vector3(1f, 5f, 0);
        Animator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(pos, boxSize, 0);
        foreach(Collider2D box in hit)
        {
            if(box.tag == "Enemy")
            {
                Attack();
            }

        }
    }

    // OnDrawGizmos()�� Scene â���� ������ Ȯ���ϱ� ����
    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(pos, boxSize);
    }

    private void Attack()
    {
        if (!isAttack) 
        {
            Debug.Log("�� ���� ����");
            Animator.SetTrigger("IEN");
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            EnemyInfo enemyInfo = enemy.GetComponent<EnemyInfo>();
            if (enemyInfo != null)
                enemyInfo.TakeDamage(100);
            
            isAttack = true;
            Invoke("ResetAttack", 1f);
        }
    }

    private void ResetAttack()
    {
        isAttack = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        //Collider2D[] collider2Ds = Physics2D.OverlapBoxAll();
    //        Debug.Log("�� ���� ����");
    //        Animator.SetTrigger("IEN");
    //        enemyInfo = collision.GetComponent<EnemyInfo>();
    //        StartCoroutine(enemyInfo.TakeDamageWithCoroutine(100, 1f));
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
    //    if(collision.tag == "Enemy" && enemy != null)
    //    {
    //        enemyInfo = collision.GetComponent<EnemyInfo>();
    //        if (enemyInfo.CurrentHp > 0) 
    //        {
    //            Debug.Log("�ٽ� ����");
    //            Animator.SetTrigger("IEN");
    //            enemyInfo = collision.GetComponent<EnemyInfo>();
    //            StartCoroutine(enemyInfo.TakeDamageWithCoroutine(100, 1f));
    //        }
    //        if (enemyInfo.CurrentHp <= 0)
    //        {
    //            enemyInfo.EnemyDead();
    //            Debug.Log("�ڷ�ƾ ����");
    //            StopAllCoroutines();
    //        }
    //    }
    //}
}
