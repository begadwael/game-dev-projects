using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] float ScoreMultiplier = 1f;

    public const string HighScoreKey = "HighScore";

    private float score;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * ScoreMultiplier;

        ScoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score)); // save HighScore
        }
    }
}
