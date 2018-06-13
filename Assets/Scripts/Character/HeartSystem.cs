using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{

    private int maxHearts = 4;
    private int healthPerHeart = 5;
    public int startHearts = 2;
    public int maxHealth;
    public static int currentHealth;
    public  bool isDead;
    public Image[] healthImages;
    public Sprite[] healthSprites;
    public GameObject ExplosionAnimation;
    public AudioClip explosionSound;
    public float v = 0f;


    void Start()
    {
        
        currentHealth = startHearts * healthPerHeart;
        maxHealth = startHearts * healthPerHeart;
        checkHealthAmount();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyProjectile3")
        {
            Debug.Log("EnemyProjectile3");

            currentHealth = currentHealth - 5;
            UpdateHearts();

        }

        if (collision.collider.tag == "EnemyProjectile2")
        {
            Debug.Log("EnemyProjectile2");
            currentHealth = currentHealth - 2;
            UpdateHearts();
        }

        if (collision.collider.tag == "EnemyProjectile")
        {
            Debug.Log("Laser Collision!");
            currentHealth--;
            UpdateHearts();
        }

        if (collision.collider.tag == "HealthDrop")
        {
            Debug.Log("Health");
            currentHealth = currentHealth + 5;
            UpdateHearts();
        }

        else
        {
            if (collision.collider.tag == "Enemy")
            {
                Debug.Log("Enemy Collision!");
                currentHealth = currentHealth - 5;
                UpdateHearts();
            }
        }
    }

    void checkHealthAmount()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;

            }
            else
            {
                healthImages[i].enabled = true;
            }
        }

        UpdateHearts();

    }
    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;
        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                if (currentHealth >= maxHealth)
                {
                    currentHealth = maxHealth;
                }

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    image.sprite = healthSprites[0];
                    Explosion();
                    Die();
                }

                i++;

                if (currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {

                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageindex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageindex];
                    empty = true;
                }
            }
        }

    }
    public void takeDamage(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }
    public void addHeart()
    {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHearts);
        checkHealthAmount();
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
}