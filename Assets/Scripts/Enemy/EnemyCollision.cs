using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{
    public GameObject ExplosionAnimation;
    public AudioClip explosionSound;
    public GameObject healthDrop;
    public float dropRate = 0.25f, randNum;
    public int health = 3;
    public float enemyPoints = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy Collision!");

        health--;

    }

    public void Update()
    {


        if (health <= 0)
        {
            Explosion();
            if (WaveSpawner.waveNum > 10)
            {
                enemyPoints = enemyPoints * 2;
            }
            HighScore.score += enemyPoints;

            itemDrop();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }
    void Explosion()
    {
        SoundEffects.Instance.MakeExplosionSound();
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimation);
        explosion.transform.position = transform.position;


    }
    void itemDrop()
    {
        randNum = Random.Range(0f, 1f);
        if (randNum <= dropRate)
        {
            Debug.Log("Dropped");
            GameObject drop = Instantiate(healthDrop);
            drop.transform.position = transform.position;

        }
    }
}

