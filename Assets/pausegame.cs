using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pausegame : MonoBehaviour {
    public string mainMenuLevel;


    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        //Application.LoadLevel(Application.loadedlevel);
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
        //int scene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(scene, LoadSceneMode.Single);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
    }
    /*void PlayerDiedEndTheGame() {
        pauseMenu.SetActive(true);
        RestartGameButton.onClick.RemoveAllListeners();
        Time.timeScale = 0f;
    }*/
}
