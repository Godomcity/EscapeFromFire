using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CollidingPlayerEventController : MonoBehaviour
{
    [SerializeField] private AudioClip hitClip;
    private Rigidbody2D movementRigidbody2D;
    private HealthSystem healthSystem;

    private int layerMaskMonster;

    public event Action OnTapMonsterJumpEvent;

    private AudioSource audioSource;

    private void Awake()
    {
        movementRigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        layerMaskMonster = LayerMask.NameToLayer("Monster");
        healthSystem = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            bool isFalling = movementRigidbody2D.velocity.y < 0 ? true : false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.NameToLayer("Monster"));

            if(true == isFalling && 
                hit.collider != null && 
                    layerMaskMonster == (layerMaskMonster | (1 << hit.collider.gameObject.layer)))
            {
                collision.gameObject.GetComponent<Monster>().MonsterDamaged();

                OnTapMonsterJumpEvent?.Invoke();

                return;
            }

            audioSource.PlayOneShot(hitClip);
            healthSystem.ChangeHealth(-1f);
        }
    }
}
