using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{
    public GameObject ExplosionAnimation;
    public int health = 3;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Projectile Collision!");

        health --;
    }

    void Update()
    {
        if (health <= 0)
        {
            Explosion();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimation);
        explosion.transform.position = transform.position;


    }
}

