using UnityEngine;

public class characterSkinChoose : SelectController
{
    [SerializeField] protected GameObject playerChoose;
    public void PlayerSkinChoiceSet()
    {
        if (GameManager.Instance.PlayerMode)
        {
            player1.SetActive(false);
            playerChoose.SetActive(true);
            levelButton.SetActive(false);
            playerMode.SetActive(false);
        }
        else if (!GameManager.Instance.PlayerMode)
        {
            player1.SetActive(false);
            player2.SetActive(false);
            playerChoose.SetActive(true);
            levelButton.SetActive(false);
            playerMode.SetActive(false);
        }
    }

}
