using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDetector : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PipeController pipeController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Portal")
            pipeController.Teleport();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GetPoint();
    }

    private void GetPoint()
    {
        gameManager.point++;
        // Player get point and present it on UI
    }
}
