using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSpeedItem : Item
{
    //[SerializeField] private ItemEffect item

    private float speedMulti = 1.7f;
    private float fastSpeedDuration = 5.0f;
    // ItemEffect에서 코루틴을 반환
    public override IEnumerator ItemEffect(GameObject player)
    {
        CharacterStat stat = player.GetComponent<CharacterStatsHandler>().CurrentStat;
        return FastSpeed(stat);  // 코루틴을 반환
    }

    // 속도 증가 효과 코루틴
    IEnumerator FastSpeed(CharacterStat playerStat)
    {
        float originSpeed = playerStat.speed;
        playerStat.speed *= speedMulti;

        yield return new WaitForSeconds(fastSpeedDuration);

        playerStat.speed = originSpeed;
    }

}
