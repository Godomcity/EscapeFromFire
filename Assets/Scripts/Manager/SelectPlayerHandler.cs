using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerHandler : MonoBehaviour
{
    List<PlayerSpawner.PlayerType> playerTypeContainer;

    private int maxDataCount;

    private void Awake()
    {
        maxDataCount = 2;
    }

    public void AddSelectData(int playerSpawnIndex)
    {
        if ((((int)PlayerSpawner.PlayerType.BLUE) > playerSpawnIndex) &&
            ((int)PlayerSpawner.PlayerType.YELLOW) < playerSpawnIndex)
            return;

        if (playerTypeContainer.Count > maxDataCount)
            return;

        playerTypeContainer.Add((PlayerSpawner.PlayerType)playerSpawnIndex);
    }


    public IReadOnlyList<PlayerSpawner.PlayerType> GetPlayerDataContainer()
    {
        return playerTypeContainer;
    }
}
