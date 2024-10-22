using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerSpawner;

public class HeartUI : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    HealthSystem healthSystem;
    Image image;
    SelectController selectController;
    GameManager gameManager;
    IReadOnlyList<PlayerType> playerTypeContainer = GameManager.Instance.SelectPlayerHandler.GetPlayerDataContainer();

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        for (int i = 0; i < 2; i++) //플레이어가 하나일때
            hearts[i].enabled = true;
    }

    public void ChangeHeart(float CurrentHealth)
    {
        int idx = (int)CurrentHealth;

        for (int i = 0; i < idx; i++)
        {
            hearts[i].sprite = fullHeart;
            hearts[idx].sprite = emptyHeart;
        }                   
    }
}