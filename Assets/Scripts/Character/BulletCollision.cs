using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{
    public int health = 3;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Projectile Collision!");

        health--;
    }

    void Update()
    {
        if (health <= 0)
        {

            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }


}

