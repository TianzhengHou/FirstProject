using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxHealth = 100;
    int currentHealth;

    public EnemyMovement callIsHitFunction;
    public EnemyHealthBar TheEnemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        TheEnemyHealthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;    
        TheEnemyHealthBar.SetHealth(currentHealth);
        Debug.Log("Enemy took damage");
        //enemy hurt animation
        callIsHitFunction.isHit();
        if(currentHealth <= 0)
        {
            enemyDie();
        }
    }

    void enemyDie()
    {
        //Die animation
        Debug.Log("Enemy died!");
        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent <EnemyMovement> ().enabled = false;
        TheEnemyHealthBar.gameObject.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
