using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private float score;
    private TMP_Text scoreText;
    private float scoreMultiplier = 100f;

    private void Awake()
    {
        score = 0;
        scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        score += Time.deltaTime * scoreMultiplier;
        scoreMultiplier += Time.deltaTime;

        GameManager.Instance.SetScore(score);

        scoreText.text = ((int)score).ToString();
    }
}
