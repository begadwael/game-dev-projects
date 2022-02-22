using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMulitplier;

    private bool ShouldCount = true;
    private float score;
    
    void Update()
    {
        if (!ShouldCount) return;

        score += Time.deltaTime * scoreMulitplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void StartTimer()
    {
        ShouldCount = true;
    }

    public int EndTimer()
    {
        ShouldCount = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
