using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> playerPrefabs;

    public enum PlayerType
    { BLUE = 1, PINK = 2, GREEN = 3, YELLOW = 4 };


    public void PlayerSpawn(int spawnID)
    {
        PlayerType type = (PlayerType)spawnID;

        Instantiate(playerPrefabs[(int)type]);
    }

}
