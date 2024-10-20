using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    private float healAmount = 1.0f;
    public override IEnumerator ItemEffect(GameObject player)
    {
        return (PlayerHeal(player));
    }

    IEnumerator PlayerHeal(GameObject player)
    {
        player.GetComponent<HealthSystem>().ChangeHealth(healAmount);

        yield return null;
    }
}
