using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int point = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void OnEnable()
    {
        PipeDetector.onGetPoint += GetPoint;
    }

    private void OnDisable()
    {
        PipeDetector.onGetPoint -= GetPoint;
    }

    private void Start()
    {
        point = 0;
    }

    private void GetPoint()
    {
        point++;
    }
}
