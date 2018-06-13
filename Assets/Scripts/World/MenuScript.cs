using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public Text highScoreText;

	// Use this for initialization
	void Start () {
        highScoreText.text = "HighScore: " + (int)PlayerPrefs.GetFloat("HighScore");
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;

	}
	
	public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;

    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void Guide()
    {
        SceneManager.LoadScene("Guide");

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
        highScoreText.text = "HighScore: 0";

    }

}
