using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCatCombat : MonoBehaviour
{
    public Rigidbody2D rb;
    //NomalAttack
    public Transform attackPoint;
    public Transform attackPointLeft;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 4f;
    float nextAttackTime = 0f;

    public bool AttackRight = true;
    

    public int attackDamage = 20;


    // Update is called once per frame
    void Update()
    {
        //NomalAttack
        if (Input.GetKeyDown(KeyCode.D))
        {
            AttackRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            AttackRight = false;
        }

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }
            
    }

    void Attack()
    {
        
        //Play the attack animation
        if(AttackRight == true)
        {
            //Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            //Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
        else
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
            //Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }            
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }
}
