using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Timers;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    public FadeController fadeController;

    private GameObject player;

    private GameObject TextBackGround;

    [SerializeField] public GameObject resultWindow;

    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject smallFireBall;
    [SerializeField] private GameObject monsterFireBall;

    [SerializeField] private float fireBall_Speed = 0.1f;
    [SerializeField] private float smallFireBall_Speed = 0.05f;
    [SerializeField] private float monsterFireBall_Speed = 1f;

    private float easy_Spawn_Speed = 1f;
    private float normal_Spawn_Speed = 1f;
    private float hard_Spawn_Speed = 0.8f;

    public static bool isEasy = false;
    public static bool isNormal = false;
    public static bool isHard = false;

    private float first_LevelUp_Time = 15f;
    private float second_LevelUp_Time = 30f;
    public float time = 0;
    private float Make5Sec;
    private float MakeMonsterFireBallTimer;

    // 임시 // 결과창이 하나만 나오게 하는 임시 변수.
    private int count;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        fadeController.FadeOut();

        LevelFireSpawn();
    }

    private void Update()
    {
        time += Time.deltaTime;
        MakeMonsterFireBallTimer += Time.deltaTime;

        // TODO : GameManager로 옮겨야 함(임시 코드 게임 종료.)
        //if (player.GetComponent<HealthSystem>().CurrentHealth == 0)
        //{
        //    if (count == 0)
        //    {
        //        Time.timeScale = 0;
        //        AudioManager.instance.audioSource.clip = AudioManager.instance.resultClip;
        //        AudioManager.instance.audioSource.Play();
        //        Instantiate(resultWindow);
        //        count = 1;
        //    }
        //}
    }

    private void LevelFireSpawn()
    {
        if (isEasy)
        {
            StartCoroutine(EasyLevel());
        }
        else if (isNormal)
        {
            StartCoroutine(NormalLevel());
        }
        else if (isHard)
        {
            StartCoroutine(HardLevel());
        }
    }

    void MakeFireBall()
    {
        GameObject go = Instantiate(fireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * fireBall_Speed;
    }

    void MakeSmallFireBall()
    {
        GameObject go = Instantiate(smallFireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * smallFireBall_Speed;
    }

    void MakeMonsterFireBall()
    {
        GameObject go = Instantiate(monsterFireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * monsterFireBall_Speed;
    }

    IEnumerator EasyLevel()
    {
        while (isEasy)
        {
            MakeSmallFireBall();

            if (time > first_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
            }

            if (time > second_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
                easy_Spawn_Speed = easy_Spawn_Speed / 2f;
                if (easy_Spawn_Speed <= 0.25f)
                {
                    easy_Spawn_Speed = 0.25f;
                }
                time = 0;
            }

            yield return new WaitForSeconds(easy_Spawn_Speed);
        }
    }

    IEnumerator NormalLevel()
    {
        while (isNormal)
        {
            MakeSmallFireBall();
            MakeFireBall();

            if (MakeMonsterFireBallTimer >= 5f)
            {
                MakeMonsterFireBall();
                MakeMonsterFireBallTimer = 0f;
            }

            if (time > first_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
            }

            if (time > second_LevelUp_Time)
            {
                normal_Spawn_Speed = normal_Spawn_Speed / 2f;
                if (normal_Spawn_Speed <= 0.8f)
                {
                    normal_Spawn_Speed = 0.8f;
                }
            }

            yield return new WaitForSeconds(normal_Spawn_Speed);
        }
    }

    IEnumerator HardLevel()
    {
        while (isHard)
        {
            MakeSmallFireBall();
            MakeFireBall();

            if (MakeMonsterFireBallTimer >= 2f)
            {
                MakeMonsterFireBall();
                MakeMonsterFireBallTimer = 0f;
            }

            if (time > first_LevelUp_Time)
            {
                MakeFireBall();
                MakeSmallFireBall();
            }

            if (time > second_LevelUp_Time)
            {
                hard_Spawn_Speed = hard_Spawn_Speed / 2f;
                if (hard_Spawn_Speed <= 0.4f)
                {
                    hard_Spawn_Speed = 0.4f;
                }
            }

            yield return new WaitForSeconds(hard_Spawn_Speed);
        }
    }
    //public void AddScore()
    //{
    //    int score = 0;
    //    score = (int)time;
    //}

    //private void Awake()
    //{
    //    time = Time.deltaTime;
    //}
}


