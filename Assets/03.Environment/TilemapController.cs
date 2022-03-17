using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x <= -13.75f)
            transform.position = new Vector2(14f, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * 4f;
    }
}
