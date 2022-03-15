using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int point = 0;

    private void Start()
    {
        point = 0;
    }

    public static void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Pause()
    {

    }
}
