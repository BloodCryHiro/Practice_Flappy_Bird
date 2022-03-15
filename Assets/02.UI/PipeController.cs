using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(transform.position.x, Random.Range(-2, 2));
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }

    public void Teleport()
    {
        transform.position = new Vector2(10, Random.Range(-2, 2));
    }
}
