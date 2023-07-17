using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [Header("Score Display")]
    [SerializeField] private TextMeshProUGUI scoreText;


    [Header("Debug - Temp Name")]
    public int score;
    public string userName;

    private void OnEnable()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void RemoveScore(int value) 
    { 
        score -= value;
        scoreText.text = score.ToString();
    }

}
