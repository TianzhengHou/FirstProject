using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 
    public Transform cat;
    public float enemyMovementSpeed = 3f;
    public float currentHitTime = 0f;
    public float hitTime = 0.15f;
    public bool startMoveFlag = false;
    private Rigidbody2D rb;
    private Vector2 EnemyMovementV2;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 driction = cat.position - transform.position;
        driction.Normalize();

        EnemyMovementV2 = driction;
    }

    void FixedUpdate()
    {
        moveEnemy(EnemyMovementV2);
    }

    public void isHit()
    {
        currentHitTime = hitTime;
    }

    void moveEnemy(Vector2 dirction)
    {
        if (currentHitTime <= 0 && startMoveFlag == true)
        {
            rb.MovePosition((Vector2)transform.position + (dirction * enemyMovementSpeed * Time.deltaTime));
        }
        if (currentHitTime <= hitTime && currentHitTime >= 0f)
        {
            currentHitTime -= Time.deltaTime;
            rb.MovePosition((Vector2)transform.position - (dirction * enemyMovementSpeed * 2.5f* Time.deltaTime));
            Debug.Log(currentHitTime);
        }
    }
}
