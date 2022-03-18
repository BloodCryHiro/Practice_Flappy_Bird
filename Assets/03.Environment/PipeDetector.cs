using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipeDetector : MonoBehaviour
{
    public UnityEvent onHitPortal;
    public static event Action onGetPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Portal")
            onHitPortal.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GetPoint();
    }

    private void GetPoint()
    {
        onGetPoint?.Invoke();
    }
}
