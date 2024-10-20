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
        Debug.Log(playerTypeContainer.Count);
        Debug.Log(GameManager.Instance.player1ChooseCharacter);
        Debug.Log(GameManager.Instance.player2ChooseCharacter);

        for (int i = 0; i < playerTypeContainer.Count; i++)
        {
            PlayerSpawn((int)(playerTypeContainer[i]));
        }
    }


    public void PlayerSpawn(int spawnID)
    {
        PlayerType type = (PlayerType)spawnID;

        Instantiate(playerPrefabs[(int)type]);
    }

}
