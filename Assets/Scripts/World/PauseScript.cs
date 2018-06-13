using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class PauseScript : MonoBehaviour {

    public Transform canvas;
    public Transform Player;

    void Start () {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();

        }
    }

    public void Resume()
    {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.GetComponent<SpaceshipMovement>().enabled = false;
                Player.GetComponent<PlayerShoot>().enabled = false;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                Player.GetComponent<SpaceshipMovement>().enabled = true;
                Player.GetComponent<PlayerShoot>().enabled = true;
            }
        }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        
    }
}

