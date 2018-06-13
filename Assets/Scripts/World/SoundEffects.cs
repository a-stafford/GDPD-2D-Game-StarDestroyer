using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour
{

    public static SoundEffects Instance;
    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;
    public AudioClip healthSound;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of soundEffects!");
        }
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    public void MakeExplosionSound()
    {
        try
        {
            MakeSound(explosionSound);
        }
        catch { }
    }
    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }
    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }
    public void MakeHealthSound()
    {
        MakeSound(healthSound);
    }
    // Play a given sound
    private void MakeSound(AudioClip originalClip)
    {
        // As it is not 3D audio clip, position doesn't matter.
        GetComponent<AudioSource>().volume = 1;
        AudioSource.PlayClipAtPoint(originalClip,
        transform.position);
    }
    
}