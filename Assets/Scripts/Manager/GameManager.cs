using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SelectDataHandler SelectDataHandler { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else if (Instance = null)
        {
            Instance = this;

            SelectDataHandler = GetComponent<SelectDataHandler>();

            DontDestroyOnLoad(gameObject);
        }
    }
}
