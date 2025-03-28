using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewMovement : MonoBehaviour
{
    [SerializeField] private AudioClip moveClip;
    [SerializeField] private AudioClip jumpClip;

    private Vector2 direction = Vector2.zero;

    private SideVeiwController controller;
    private CollidingPlayerEventController collidingPlayerEventController;

    private Rigidbody2D movementRigidbody2D;
    private SpriteRenderer spriteRenderer;
    private CharacterStatsHandler statHandler;
    private HealthSystem healthSystem;

    private AudioSource audioSource;

    private bool isGround = true;

    private float statSpeed => statHandler.CurrentStat.speed;

    private void Awake()
    {
        controller = GetComponent<SideVeiwController>();
        movementRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        statHandler =  GetComponent<CharacterStatsHandler>();
        healthSystem = GetComponent<HealthSystem>();
        collidingPlayerEventController = GetComponent<CollidingPlayerEventController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnJumpEvent += Jump;
        collidingPlayerEventController.OnTapMonsterJumpEvent += DoubleJump;
    }

    private void FixedUpdate()
    {
        ApplyDirectionMove();
    }

    private void ApplyDirectionMove()
    {
        Vector2 currentVelocity = movementRigidbody2D.velocity;
        currentVelocity.x = (direction * statSpeed * (healthSystem.IsAttacked ? 0 : 1)).x;
        movementRigidbody2D.velocity = currentVelocity;
    }

    private void Move(Vector2 _direction)
    {
        if (_direction.x != 0)
        {
            audioSource.clip = moveClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }

        direction = _direction;

        bool isFilpX = controller.direction.x < 0;

        spriteRenderer.flipX = isFilpX;
    }

    private void Jump()
    {
        if (false == isGround)
            return;

        audioSource.PlayOneShot(jumpClip);

        movementRigidbody2D.AddForce(Vector2.up * statHandler.CurrentStat.jumpPower, ForceMode2D.Impulse);

    }
    private void DoubleJump()
    {
        Vector2 currentVelocity = movementRigidbody2D.velocity;
        currentVelocity.y = 0f;

        movementRigidbody2D.velocity = currentVelocity;

        movementRigidbody2D.AddForce(Vector2.up * (statHandler.CurrentStat.jumpPower * 0.8f), ForceMode2D.Impulse);

        audioSource.PlayOneShot(jumpClip);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
