using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {
    public GameObject ExitPanel;
	public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        ExitPanel.SetActive(true);
        
    }
    public void YesExit()
    {
        Application.Quit();
    }
    public void NoExit()
    {
        ExitPanel.SetActive(false);
    }
        }
