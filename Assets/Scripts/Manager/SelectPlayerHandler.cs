using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerHandler : MonoBehaviour
{
    List<PlayerSpawner.PlayerType> playerTypeContainer = new List<PlayerSpawner.PlayerType>();

    private int maxDataCount;

    private void Awake()
    {
        maxDataCount = 2;
    }

    public void AddSelectData(int playerSpawnIndex)
    {
        if (playerTypeContainer.Count > maxDataCount)
            return;

        playerTypeContainer.Add((PlayerSpawner.PlayerType)playerSpawnIndex);
    }

    public IReadOnlyList<PlayerSpawner.PlayerType> GetPlayerDataContainer()
    {
        return playerTypeContainer;
    }
}