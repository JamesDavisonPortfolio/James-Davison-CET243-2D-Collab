using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform hitZone;
    public int damage = 1;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitZone.position, attackRange, EnemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Vector2 direction = enemy.transform.position - gameObject.transform.position;
            enemy.GetComponent<EnemyActivation>().TakeDamage(damage, direction);
        }
    }
}
