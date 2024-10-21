using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Balls : MonoBehaviour
{
    [SerializeField] private AudioClip groundClip;
    [SerializeField] private AudioClip playerHitClip;

    //특수 불꽃의 몬스터 소환 
    private bool isDestroy = false;
    Animator animator;
    Rigidbody2D rgbd;
    HealthSystem healthSystem;
    AudioSource audioSource;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();    
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {          
            animator.SetBool("isDestroy", true);
            Destroy(this.gameObject, 0.4f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rgbd.constraints = RigidbodyConstraints2D.FreezePositionY;
            OnTriggerEffect(collision);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.volume = 0.5f;
            audioSource.clip = playerHitClip;
            audioSource.Play();
            animator.SetBool("isDestroy", true);
            Destroy(this.gameObject, 0.4f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rgbd.constraints = RigidbodyConstraints2D.FreezePositionY;
            collision.gameObject.GetComponent<HealthSystem>().ChangeHealth(-1);
        }
    }

    protected abstract void OnTriggerEffect(Collider2D collision);

    //플레이어가 맞을 때 체력의 변화
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }   
}
