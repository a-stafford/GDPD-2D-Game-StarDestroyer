using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public static float score = 0f;
    public Image backgroundImg;
    public Text ScoreText, DeathScoreText, HSText, HText;
    public GameObject deathScreen;
    public bool isDead = false;
    private float transition = 0.0f;

    void Start()
    {
        ScoreText = GetComponent<Text>();
        score = 0;
        HSText.text = "HighScore: " + (int)PlayerPrefs.GetFloat("HighScore");
        deathScreen.SetActive(false);

    }

    void Update()
    {
        ScoreText.text = "Score: " + score;
        DeadScreen();


    }

    void DeadScreen()
    {
        if (HeartSystem.currentHealth <= 0)
        {
            transition += Time.deltaTime;
            backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
            deathScreen.SetActive(true);
            DeathScoreText.text = "Final Score: " + ((int)score).ToString();
        }
        
       


        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);

        }
    }

}

