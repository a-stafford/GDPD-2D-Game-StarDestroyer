using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    public float maxDelay = 0f;
    private float fireDelay;
    float cooldownTimer = 0f;
    public AudioClip enemyShotSound;

    // Update is called once per frame
    void Update()
    {
        fireDelay = Random.Range(0f, maxDelay);
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            Debug.Log("Enemy Shoot");
            cooldownTimer = fireDelay;
            SoundEffects.Instance.MakeEnemyShotSound();
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);
            bulletGO.layer = gameObject.layer;
        }
    }

    
}
