using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameStart = false;
    public int point = 0;

    private void Start()
    {
        point = 0;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameStart)
        {
            isGameStart = true;
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        GameObject.Find("Canvas").GetComponent<MainGameUI>().EnterDeathMenu();
    }
}
