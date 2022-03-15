using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private CircleCollider2D circleCollider;
    private Rigidbody2D rb;
    private bool alive = true;
    private bool jump = false;
    [SerializeField] private float jumpForce = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
    }

    private void FixedUpdate()
    {
        if (jump && alive)
        {
            Jump();
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pipe")
            Dead();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Dead()
    {
        // Make it visually better
        rb.velocity = Vector2.zero;
        circleCollider.enabled = false;
        alive = false;
        gameManager.GameOver();
    }

    // Setup a timer to ensure player can't jump too frequently
}
