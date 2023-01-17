using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RayMovement : MonoBehaviour
{
    public Transform Cats;
    public float RayGunSpeed = 4.9f;
    public Rigidbody2D rb;
    const float Distance = 1f;


    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    Vector2 RayDri;

    void Update()
    {
        RayDri = (Cats.position - transform.position);

        if ((transform.position - Cats.position).magnitude > Distance )
        {
            rb.MovePosition(rb.position + RayDri * Time.fixedDeltaTime * RayGunSpeed);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
