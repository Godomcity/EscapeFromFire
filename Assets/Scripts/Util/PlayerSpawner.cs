using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> playerPrefabs;

    public enum PlayerType
    { BLUE, PINK, GREEN, YELLOW };


    public void PlayerSpawn(int spawnID)
    {
        PlayerType type = (PlayerType)spawnID;

        Instantiate(playerPrefabs[(int)type]);
    }

}
