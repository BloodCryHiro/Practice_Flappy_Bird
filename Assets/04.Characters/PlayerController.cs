using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    private CapsuleCollider2D playerCollider;
    private Rigidbody2D rb;
    private bool alive = true;
    private bool jump = false;
    [SerializeField] private float jumpForce = 15f;
    public static event Action onPlayerDeath;
    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
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
        PlaySound(jumpSound);
    }

    private void Dead()
    {
        // Make it visually better
        rb.velocity = Vector2.zero;
        playerCollider.enabled = false;
        alive = false;
        PlaySound(deathSound);
        onPlayerDeath?.Invoke();
    }

    private void PlaySound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
