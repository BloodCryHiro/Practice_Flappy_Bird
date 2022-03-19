using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private IEnumerator BlackOutCoroutine()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        StartCoroutine(BlackOutCoroutine());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
