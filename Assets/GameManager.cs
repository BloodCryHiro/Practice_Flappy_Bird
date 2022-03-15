using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MainGameUI MGUI;
    public int point = 0;

    private void Start()
    {
        point = 0;
    }

    public void GameOver()
    {
        GameObject.Find("Canvas").GetComponent<MainGameUI>().EnterDeathMenu();
    }
}
