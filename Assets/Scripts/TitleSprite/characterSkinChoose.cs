using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class characterSkinChoose : SelectController
{
    [SerializeField] protected GameObject playerChoose;
    GameObject whoPlayerChooseMode;
    [SerializeField] private Sprite MaskDudde;
    [SerializeField] private Sprite NinjaFrog;
    [SerializeField] private Sprite PinkMan;
    [SerializeField] private Sprite VirtualGuy;
    [SerializeField] private Image player1FGimage;
    [SerializeField] private Image player2FGimage;
    public void PlayerSkinChoiceSet()
    {
        whoPlayerChooseMode = EventSystem.current.currentSelectedGameObject;
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
    public void MaskDudechoose()
    {
        if (whoPlayerChooseMode.name == "Player1")
        {
            player1FGimage.sprite = MaskDudde;
            GameManager.Instance.player1ChooseCharacter=0;

        }
        else if (whoPlayerChooseMode.name == "Player2")
        {
            player2FGimage.sprite = MaskDudde;
            GameManager.Instance.player2ChooseCharacter=0;

        }
        ObjectSetAcitveTrue();
    }
    public void NinJaForgchoose()
    {
        if (whoPlayerChooseMode.name == "Player1")
        {
            player1FGimage.sprite = NinjaFrog;
            GameManager.Instance.player1ChooseCharacter=1;

        }
        else if (whoPlayerChooseMode.name == "Player2")
        {
            player2FGimage.sprite = NinjaFrog;
            GameManager.Instance.player2ChooseCharacter=1;

        }
        ObjectSetAcitveTrue();
    }
    public void PinkManchoose()
    {
        if (whoPlayerChooseMode.name == "Player1")
        {
            player1FGimage.sprite = PinkMan;
            GameManager.Instance.player1ChooseCharacter=2;

        }
        else if (whoPlayerChooseMode.name == "Player2")
        {
            player2FGimage.sprite = PinkMan;
            GameManager.Instance.player2ChooseCharacter=2;

        }
        ObjectSetAcitveTrue();
    }
    public void VirtualGuychoose()
    {
        if (whoPlayerChooseMode.name == "Player1")
        {
            player1FGimage.sprite = VirtualGuy;
            GameManager.Instance.player1ChooseCharacter=3;

        }
        else if (whoPlayerChooseMode.name == "Player2")
        {
            player2FGimage.sprite = VirtualGuy;
            GameManager.Instance.player2ChooseCharacter=3;

        }
        ObjectSetAcitveTrue();
    }

    public void ObjectSetAcitveTrue()
    {
        if (GameManager.Instance.PlayerMode)
        {
            player1.SetActive(true);
            playerChoose.SetActive(false);
            levelButton.SetActive(true);
            playerMode.SetActive(true);

        }
        else if (!GameManager.Instance.PlayerMode)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            playerChoose.SetActive(false);
            levelButton.SetActive(true);
            playerMode.SetActive(true);
        }
    }

}
