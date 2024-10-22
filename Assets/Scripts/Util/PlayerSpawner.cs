using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] List<GameObject> playerPrefabs;
    [SerializeField] private HeartUI heartUI1;
    [SerializeField] private HeartUI heartUI2;
    HealthSystem healthSystem;
    

    public enum PlayerType
    { BLUE = 3, PINK = 2, GREEN = 1, YELLOW = 0 };


    private void Awake()
    {
        gameManager = GameManager.Instance;

        IReadOnlyList<PlayerType> playerTypeContainer = GameManager.Instance.SelectPlayerHandler.GetPlayerDataContainer();

        GameObject player1 = PlayerSpawn((int)(playerTypeContainer[0]));
        //player1.GetComponent 여기서 헬스시스템에 접근하여 이벤트 등록
        player1.GetComponent<HealthSystem>().OnDamage += heartUI1.ChangeHeart;
        player1.GetComponent<HealthSystem>().OnHeal += heartUI1.ChangeHeart;
        //이벤트 등록 OnDamage 이벤트 옮기기
        player1.GetComponent<InputMapHandler>().SwitchActionMap("Player1");
        gameManager.player1 = player1;

        if (playerTypeContainer.Count > 1)
        {
            GameObject player2 = PlayerSpawn((int)(playerTypeContainer[1]));
            player2.GetComponent<InputMapHandler>().SwitchActionMap("Player2");
            player2.GetComponent<HealthSystem>().OnDamage += heartUI2.ChangeHeart;
            player2.GetComponent<HealthSystem>().OnHeal += heartUI2.ChangeHeart;
            gameManager.player2 = player2;
        }
    }

    private void Start()
    {
       
       
    }


    public GameObject PlayerSpawn(int spawnID)
    {
        PlayerType type = (PlayerType)spawnID;

        return Instantiate(playerPrefabs[(int)type]);
    }

}
