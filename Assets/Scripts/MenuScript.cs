using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {


    public Canvas quitMenu;
    public Canvas howToMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        howToMenu = howToMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = startText.GetComponent<Button>();

        quitMenu.enabled = false;
    }

    public void howTo()
    {
        quitMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        howToMenu.enabled = true;
    }
	
    public void howToPress()
    {
        quitMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        howToMenu.enabled = false;
    }

	public void exitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        howToMenu.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        howToMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
