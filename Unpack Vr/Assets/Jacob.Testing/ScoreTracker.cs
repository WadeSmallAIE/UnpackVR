using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score;
    [Header("Debug - Temp Name")]
    public string userName;

    private void OnEnable()
    {
        score = 0;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void RemoveScore(int value) 
    { 
        score -= value;
    }

}
