using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] private GameObject waitForJump;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private TMP_Text pointText;

    private void Update()
    {
        pointText.text = "Point: " + GameObject.Find("GameManager").GetComponent<GameManager>().point;

        if (Input.GetKeyDown(KeyCode.Space))
            waitForJump.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerController.onPlayerDeath += EnterDeathMenu;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDeath -= EnterDeathMenu;
    }

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

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void EnterDeathMenu()
    {
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
    }

    public void RestartGame()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
