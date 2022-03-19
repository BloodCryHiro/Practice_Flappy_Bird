using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x <= -14)
            transform.position = new Vector2(14f, 0f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }
}
