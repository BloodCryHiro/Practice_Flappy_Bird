using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;

    private void Update()
    {
        pointText.text = "Point: " + GameManager.point;
    }
}
