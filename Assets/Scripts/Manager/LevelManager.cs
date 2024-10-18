using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Timers;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject smallFireBall;
    [SerializeField] private GameObject monsterFireBall;

    [SerializeField] private float fireBall_Speed = 0.1f;
    [SerializeField] private float smallFireBall_Speed = 0.05f;
    [SerializeField] private float monsterFireBall_Speed = 1f;

    private float easy_Spawn_Speed = 1f;
    private float normal_Spawn_Speed = 0.8f;
    private float hard_Spawn_Spawn_Speed = 0.5f;

    public static bool isEasy = true;
    public static bool isNormal = false;
    public static bool isHard = true;

    private float first_LevelUp_Time = 15f;
    private float second_LevelUp_Time = 30f;
    private float time = 0;
    private float Make5Sec;
    private float MakeMonsterFireBallTimer;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }       
    }

    void Start()
    {
        LevelFireSpawn();

        //InvokeRepeating("MakeFireBall", 0.5f, 1f);
        //InvokeRepeating("MakeSmallFireBall", 0.5f, 1f);
        //InvokeRepeating("MakeMonsterFireBall", 0.5f, 1f);
    }

    private void Update()
    {
        time += Time.deltaTime;
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

            if (time > first_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
            }

            if (time > second_LevelUp_Time)
            {
                MakeMonsterFireBall();
                normal_Spawn_Speed = normal_Spawn_Speed / 2f;
                if (normal_Spawn_Speed <= 0.2f)
                {
                    normal_Spawn_Speed = 0.2f;
                }
            }
            time = 0f;
            yield return new WaitForSeconds(normal_Spawn_Speed);
        }
    }

    IEnumerator HardLevel()
    {
        while (isHard)
        {            
            MakeSmallFireBall();
            MakeFireBall();
            MakeMonsterFireBallTimer = time;

            if (time > first_LevelUp_Time)
            {
                MakeFireBall();
                MakeSmallFireBall();
            }

            if (time > second_LevelUp_Time)
            {
                if(MakeMonsterFireBallTimer >= 5f)
                {
                    MakeMonsterFireBall();
                    MakeMonsterFireBallTimer = 0;
                }
                
                hard_Spawn_Spawn_Speed = hard_Spawn_Spawn_Speed / 2f;
                if (hard_Spawn_Spawn_Speed <= 0.125f)
                {
                    hard_Spawn_Spawn_Speed = 0.125f;
                }
            }            
            yield return new WaitForSeconds(hard_Spawn_Spawn_Speed);
        }
    }
}
