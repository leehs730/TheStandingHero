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
        pos = transform.position + pos;
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

    // OnDrawGizmos()는 Scene 창에서 눈으로 확인하기 위함
    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(pos, boxSize);
    }

    private void Attack()
    {
        if (!isAttack) 
        {
            Debug.Log("적 공격 시작");
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

}
