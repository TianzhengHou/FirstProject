using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //movement
    public float moveSpeed = 6f;
    public float dashSpeed = 18f;
    public float dashingTime = 0f;
    public float dashCoolDown = 1f;


    public Vector2 moveDir;

    public Rigidbody2D rb;
    public Animator animator;

    public bool isDashing = false;

    Vector2 CatMovement;

    // Update is called once per frame

    void Update()
    {

        //Input
        CatMovement.x = UnityEngine.
            Input.GetAxis("Horizontal");
        CatMovement.y = UnityEngine.
            Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.K) && dashCoolDown >= 1f)
        {
            isDashing = true;
            dashingTime = 0.2f;
            dashCoolDown = 0f;
        }

        //movement animator
        animator.SetFloat("Horizontal", CatMovement.x);
        animator.SetFloat("Vertical", CatMovement.y);
        animator.SetFloat("Speed", CatMovement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        //Movement

            rb.MovePosition
            (rb.position + 
            CatMovement * 
            moveSpeed * 
            Time.fixedDeltaTime);


            if (dashCoolDown >= 0 && dashCoolDown <= 1f)
            {
                dashCoolDown += Time.fixedDeltaTime;
            }
            if (isDashing == true)
            {
                dashingTime -= Time.fixedDeltaTime;
                rb.MovePosition(rb.position + CatMovement * dashSpeed * Time.fixedDeltaTime);
                if (dashingTime <= 0)
                {
                    isDashing = false;
                }
            }

    }
}
