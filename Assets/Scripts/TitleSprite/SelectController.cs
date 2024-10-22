using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectController : MonoBehaviour
{
     
     public GameObject player1;
     public GameObject player2;
     protected GameObject levelButton;
     protected GameObject playerMode;


    protected string singleMode = "Now - SinglePlay";
    protected string MultiMode = "Now - MultiPlay";
    public void Awake()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("PlayerDisplay").transform.Find("Player2").gameObject;
        levelButton = GameObject.Find("LevelButton");
        playerMode = GameObject.Find("PlayMod");
    }
}
