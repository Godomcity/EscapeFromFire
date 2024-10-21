using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject player1;
    public GameObject player2;

    private float score;
    private float highScore;

    private int deathCount = 0;

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

    private void Start()
    {
        SceneManager.sceneLoaded += GetPlayer;
    }

    public float GetHighScore()
    {
        if (highScore < score)
        {
            highScore = score;
        }
        return highScore;
    }

    public float GetScore()
    {
        return score;
    }

    public void SetScore(float scoreValue)
    {
        score = scoreValue;
    }

    void GetPlayer(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            if (PlayerMode)
            {
                player1.GetComponent<HealthSystem>().OnDeath += GameEnd;
            }
            else
            {
                player1.GetComponent<HealthSystem>().OnDeath += DeathCountIncrease;
                player2.GetComponent<HealthSystem>().OnDeath += DeathCountIncrease;
            }
        }
    }

    private void DeathCountIncrease()
    {
        deathCount++;

        if (deathCount == 2)
        {
            GameEnd();
            deathCount = 0;
        }
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        AudioManager.instance.audioSource.clip = AudioManager.instance.resultClip;
        AudioManager.instance.audioSource.Play();
        Instantiate(LevelManager.Instance.resultWindow);
    }
}
