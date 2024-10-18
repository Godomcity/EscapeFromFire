using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private GameObject useItemPlayer;

    public abstract void ItemEffect(GameObject player);

    // Start is called before the first frame update
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            useItemPlayer = collision.gameObject;

            ItemEffect(useItemPlayer);

            Destroy(this.gameObject);
        }
    }
}
