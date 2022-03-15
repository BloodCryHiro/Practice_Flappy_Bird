using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int point = 0;

    private void Start()
    {
        point = 0;
    }

    static public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(0);
    }
}
