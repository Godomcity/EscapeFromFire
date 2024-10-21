using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem healthSystem;
    private new Rigidbody2D rigidbody;
    private new Animator animator;
    private AnimationController controller;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<AnimationController>();
        healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            behaviour.enabled = false;
        }

        controller.enabled = true;
        animator.enabled = true;

        Destroy(gameObject, 0.5f);
    }
}