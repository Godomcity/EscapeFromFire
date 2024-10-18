using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SelectPlayerHandler SelectPlayerHandler { get; private set; }
    public bool PlayerMode = true;  //true�� �̱�, false�� ��Ƽ

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("�����?");
            Destroy(this);
        }
        else if (Instance = null)
        {
            Debug.Log("���䰡?");
            Instance = this;

            SelectPlayerHandler = GetComponent<SelectPlayerHandler>();

            DontDestroyOnLoad(gameObject);
        }
        Debug.Log(GameManager.Instance);
    }
}
