using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] protected GameObject player1;
    [SerializeField] protected GameObject player2;
    [SerializeField] protected GameObject playerChoose;
    [SerializeField] protected Transform player1Transform;
    [SerializeField] protected static TextMeshProUGUI playerModeTxt;

    protected string singleMode = "Now SinglePlay";
    protected string MultiMode = "Now MultiPlay";

    protected Vector2 player1SingleModeVector = new Vector2(660,740);
    protected Vector2 player1MultiModeVector = new Vector2(960, 740);
    public void Start()
    {
        playerModeTxt.text = singleMode;
    }
    public void PlayerSkinChoiceSet()
    {
        if (playerModeTxt.text == singleMode)
        {
            player1.SetActive(false);
            playerChoose.SetActive(true);
        }
        else if (playerModeTxt.text==MultiMode)
        {
            player1.SetActive(false);
            player2.SetActive(false);
            playerChoose.SetActive(true);
        }
    }
    public void playerModeChoiceSet()
    {
        if (playerModeTxt.text == singleMode)
        {
            playerModeTxt.text=MultiMode;
            player1Transform.position = player1MultiModeVector;
        }else if (playerModeTxt.text==MultiMode)
        {
            playerModeTxt.text = singleMode;
            player1Transform.position = player1SingleModeVector;
        }

    }
}
public class SkinSelectController : SelectController
{

}
public class PlayModeSelectController : SelectController
{

}
