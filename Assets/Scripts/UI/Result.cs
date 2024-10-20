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
        timeText.text = $"시간 : {LevelManager.Instance.time.ToString("N0")}초";
        //currentScoreText.text = $"현재 점수 : {GameManager.Instance.GetScore().ToString("N0")}점";
        //higfScoreText.text = $"최고 점수 : {GameManager.Instance.GetHighScore().ToString("N0")}점";
    }
}
