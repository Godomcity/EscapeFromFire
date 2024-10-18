using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    private float healAmount = 1.0f;
    public override void ItemEffect(GameObject player)
    {
        player.GetComponent<HealthSystem>().ChangeHealth(healAmount);

        Debug.Log("Heal");
    }
}
