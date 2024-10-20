using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text higfScoreText;

    void Start()
    {
        timeText.text = $"�ð� : {LevelManager.Instance.time.ToString("N0")}��";
        //currentScoreText.text = $"���� ���� : {GameManager.Instance.GetScore().ToString("N0")}��";
        //higfScoreText.text = $"�ְ� ���� : {GameManager.Instance.GetHighScore().ToString("N0")}��";
    }
}
