using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlowItem : Item
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject smallFirePrefab;

    private float fireSlowDuration = 3.0f;

    public override void ItemEffect(GameObject player)
    {
        StartCoroutine(FireSlow());
    }

    IEnumerator FireSlow()
    {
        firePrefab.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        smallFirePrefab.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

        yield return new WaitForSeconds(fireSlowDuration);

        firePrefab.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        smallFirePrefab.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
    }
}
