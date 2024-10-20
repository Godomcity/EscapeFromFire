using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SelectPlayerHandler SelectPlayerHandler { get; private set; }
    public bool PlayerMode = true;  //true는 싱글, false는 멀티
    public int player1ChooseCharacter = 100;
    public int player2ChooseCharacter = 100;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else if (Instance == null)
        {
            Instance = this;

            SelectPlayerHandler = GetComponent<SelectPlayerHandler>();

            DontDestroyOnLoad(gameObject);
        }
    }
}
