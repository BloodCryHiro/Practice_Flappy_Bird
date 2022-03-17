using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CapsuleCollider2D playerCollider;
    private Rigidbody2D rb;
    private bool alive = true;
    private bool jump = false;
    [SerializeField] private float jumpForce = 15f;
    public static event Action onPlayerDeath;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
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
        playerCollider.enabled = false;
        alive = false;
        onPlayerDeath?.Invoke();
    }

    // Setup a timer to ensure player can't jump too frequently
}
