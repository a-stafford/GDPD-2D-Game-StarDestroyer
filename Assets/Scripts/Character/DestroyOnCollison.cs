using UnityEngine;
using System.Collections;

public class DestroyOnCollison : MonoBehaviour
{

    public int health = 1;
    public AudioClip healthSound;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            Debug.Log("Health Collision!");
            health--;
      
            }
            else
            {
                    Debug.Log("avoided");
                Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
            }
        

    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SoundEffects.Instance.MakeHealthSound();
        }
    }
}