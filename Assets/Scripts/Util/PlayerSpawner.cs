using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> playerPrefabs;

    public enum PlayerType
    { BLUE = 3, PINK = 2, GREEN = 1, YELLOW = 0 };


    private void Start()
    {
        IReadOnlyList<PlayerType> playerTypeContainer =  GameManager.Instance.SelectPlayerHandler.GetPlayerDataContainer();

        GameObject player1 = PlayerSpawn((int)(playerTypeContainer[0]));
        player1.GetComponent<InputMapHandler>().SwitchActionMap("Player1");

        if(playerTypeContainer.Count > 1)
        {
            GameObject player2 = PlayerSpawn((int)(playerTypeContainer[1]));
            player2.GetComponent<InputMapHandler>().SwitchActionMap("Player2"); ;
        }
    }


    public GameObject PlayerSpawn(int spawnID)
    {
        PlayerType type = (PlayerType)spawnID;

        return Instantiate(playerPrefabs[(int)type]);
    }

}
