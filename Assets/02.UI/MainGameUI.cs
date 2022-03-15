using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    private bool isGamePause = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deathMenu;

    [SerializeField] private TMP_Text pointText;

    private void Update()
    {
        pointText.text = "Point: " + GameObject.Find("GameManager").GetComponent<GameManager>().point;
    }

    public void PauseGame()
    {
        if (!isGamePause)
        {
            Time.timeScale = 0f;
            isGamePause = true;
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        if (isGamePause)
        {
            Time.timeScale = 1f;
            isGamePause = false;
            pauseMenu.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterDeathMenu()
    {
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
