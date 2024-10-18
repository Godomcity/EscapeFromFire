using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDataHandler : MonoBehaviour
{
    // MainScene 플레이어 생성시 필요한 값의 저장이 필요함.

    // 무조건 필요한 정보
    // 플레이어 1의 인덱스값.

    // 필요할지 없을지 모르는 정보
    // 플레이어 2의 인덱스값

    // 플레이어 생성 인덱스값을 받는다 LIST로...

    // 생성시 해당 리스트 순회하며 있는거 전부 생성하는 구문.

    List<PlayerSpawner.PlayerType> playerTypeContainer;

    private int maxDataCount;

    private void Awake()
    {
        maxDataCount = 2;
    }

    public void AddPlayer(int playerSpawnIndex)
    {
        if ((((int)PlayerSpawner.PlayerType.BLUE) > playerSpawnIndex) &&
            ((int)PlayerSpawner.PlayerType.YELLOW) < playerSpawnIndex)
            return;

        if (playerTypeContainer.Count > maxDataCount)
            return;

        playerTypeContainer.Add((PlayerSpawner.PlayerType)playerSpawnIndex);
    }
}
