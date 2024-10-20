using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SelectController : MonoBehaviour
{

     protected GameObject player1;
     [SerializeField] protected GameObject player2;
     protected GameObject levelButton;
     protected GameObject playerMode;


    protected string singleMode = "Now - SinglePlay";
    protected string MultiMode = "Now - MultiPlay";
    public void Awake()
    {
        player1 = GameObject.Find("Player1");
        levelButton = GameObject.Find("LevelButton");
        playerMode = GameObject.Find("PlayMod");

    }


}
