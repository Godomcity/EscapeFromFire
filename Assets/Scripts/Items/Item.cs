using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;
    private GameObject useItemPlayer;

    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    public abstract IEnumerator ItemEffect(GameObject player);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

            rigidbody2D.gravityScale = 0f;
            rigidbody2D.velocity = Vector3.zero;

            Destroy(this.gameObject, 1f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            useItemPlayer = collision.gameObject;

            if (collision == null)
                return;

            itemManager.UseItem(this, useItemPlayer);

            Destroy(this.gameObject, 0.1f);
        }
    }
}
