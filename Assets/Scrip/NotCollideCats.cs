using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCollideCats : MonoBehaviour
{
    public string TagToIgnore = "Player";

    // Start is called before the first frame update
    void OnCollisonENter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagToIgnore)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
}