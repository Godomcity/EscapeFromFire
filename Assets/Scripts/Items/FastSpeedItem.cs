using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSpeedItem : Item
{
    //[SerializeField] private ItemEffect item

    private float speedMulti = 1.7f;
    private float fastSpeedDuration = 5.0f;
    // ItemEffect���� �ڷ�ƾ�� ��ȯ
    public override IEnumerator ItemEffect(GameObject player)
    {
        CharacterStat stat = player.GetComponent<CharacterStatsHandler>().CurrentStat;
        return FastSpeed(stat);  // �ڷ�ƾ�� ��ȯ
    }

    // �ӵ� ���� ȿ�� �ڷ�ƾ
    IEnumerator FastSpeed(CharacterStat playerStat)
    {
        float originSpeed = playerStat.speed;
        playerStat.speed *= speedMulti;

        yield return new WaitForSeconds(fastSpeedDuration);

        playerStat.speed = originSpeed;
    }

}
