using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public GameObject bulletSpawn2;
    public AudioClip playerShotSound;

    public float ShotDelay = 0.25f;
    float shotCooldown = 0;

    // Update is called once per frame
    void Update()
    {
        shotCooldown -= Time.deltaTime;
        if (Input.GetKeyDown("mouse 0"))
        {
            Debug.Log("Single Shot fired");
            SoundEffects.Instance.MakePlayerShotSound();
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        }

        shotCooldown -= Time.deltaTime;
        if (Input.GetKey("mouse 1") && shotCooldown <= 0)
        {
            Debug.Log("Multiple Shot fired");
            shotCooldown = ShotDelay;
            SoundEffects.Instance.MakePlayerShotSound();
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        }
    }
}

