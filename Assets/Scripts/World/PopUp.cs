using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text PopUpText;
    public GameObject PopUpScreen;
    public float timer = 5f;

    void Start()
    {
        PopUpText = GetComponent<Text>();
        PopUpText.enabled = false;

    }
    void Update()
    {
        Spawn();
        Delay();
        Complete();
        Delay2();
    }
    void Spawn()
    {
        if (WaveSpawner.waveS == true)
        {
            PopUpText.text = "Wave " + WaveSpawner.waveNum + " Starting";
            PopUpText.enabled = true;
            timer = 3f;
            WaveSpawner.waveS = false;
            Delay2();
        }

    }

    void Complete()
    {
        if (WaveSpawner.waveC == true)
        {

            PopUpText.text = "Wave Completed!";
            PopUpText.enabled = true;
            timer = 5f;
            WaveSpawner.waveC = false;
            Delay();
        }
    }


    void Delay()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            
            PopUpText.enabled = false;

        }
    }

    void Delay2()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            PopUpText.enabled = false;

        }
    }

    
}
