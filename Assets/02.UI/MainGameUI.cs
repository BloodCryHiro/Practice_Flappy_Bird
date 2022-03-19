using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject waitForJump;
    [SerializeField] private TMP_Text pointText;
    private bool isGameStart = false;
    private bool isGamePause = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        pointText.text = "Point: " + GameManager.Instance.point;

        if (Input.GetKeyDown(KeyCode.Space) && !isGameStart && !isGamePause)
        {
            waitForJump.SetActive(false);
            Time.timeScale = 1f;
            isGameStart = true;
        }
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
        isGamePause = true;
    }

    private IEnumerator ResumeGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(.2f);
        if (isGameStart)
            Time.timeScale = 1f;
        isGamePause = false;
    }

    public void ResumeGame()
    {
        StartCoroutine(ResumeGameCoroutine());
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
        animator.SetTrigger("DeathMenuIn");
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
