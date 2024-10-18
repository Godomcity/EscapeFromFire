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
    [SerializeField] protected TextMeshProUGUI playerModeTxt;
    [SerializeField] private GameObject levelButton;
    [SerializeField] private GameObject playerMode;

    protected string singleMode = "Now SinglePlay";
    protected string MultiMode = "Now MultiPlay";

    protected Vector2 player1SingleModeVector = new Vector2(660, 740);
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
            levelButton.SetActive(false);
            playerMode.SetActive(false);
        }
        else if (playerModeTxt.text==MultiMode)
        {
            player1.SetActive(false);
            player2.SetActive(false);
            playerChoose.SetActive(true);
            levelButton.SetActive(false);
            playerMode.SetActive(false);
        }
    }
    public void playerModeChoiceSet()
    {
        //Debug.Log($"{ playerModeTxt.text} +  +{singleMode}+  + {MultiMode}");
        if (playerModeTxt.text == singleMode)
        {
            playerModeTxt.text=MultiMode;
            player2.SetActive(true);
            player1Transform.position = player1SingleModeVector;
        }
        else if (playerModeTxt.text==MultiMode)
        {
            playerModeTxt.text = singleMode;
            player2.SetActive(false);
            player1Transform.position = player1MultiModeVector;
        }

    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(https://nbcamp.spartacodingclub.kr/);
        #else
            Application.Quit();
        #endif
    }
}
public class characterSkinChoose : MonoBehaviour
{

}
public class PlayModeSelectController : SelectController
{

}
