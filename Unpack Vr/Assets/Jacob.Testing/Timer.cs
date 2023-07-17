using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [Header("Time Settings")]
    [SerializeField] private float seconds;
    [SerializeField] private float minutes;
    [SerializeField] private bool countDown;
    [SerializeField] private bool hasLimit;
    [Tooltip("In seconds total")]
    [SerializeField] private float limit;
    [Header("Score")]
    [SerializeField] private ScoreTracker scoreTracker;
    //[SerializeField] private GameObject scoreBoard;
    //[SerializeField] private ScoreboardTable scoreboardTable;
    [Header("Debug")]
    [SerializeField] private float actualSeconds;
    [SerializeField] private bool timeout = false;


   void Start()
    {
        actualSeconds = seconds + (minutes * 60);
        //scoreBoard.SetActive(false);
        timeout = false;
    }

    void Update()
    {
        actualSeconds = countDown ? actualSeconds -= Time.deltaTime : actualSeconds += Time.deltaTime;

        seconds = countDown ? seconds -= Time.deltaTime : seconds += Time.deltaTime;

        CalculateActualSeconds();

        if (hasLimit && ((countDown && actualSeconds <= limit) || (!countDown && actualSeconds >= limit))) 
        {
            actualSeconds = limit;
            DisplayTime();
            text.color = Color.red;
            enabled = false;
            GameOver();
        }

        DisplayTime();
        TimeOutAudio();
    }

    private void DisplayTime()
    {
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CalculateActualSeconds()
    {
        if(!countDown) 
        {
            if (seconds >= 59)
            {
                minutes++;
                seconds = 0;
                actualSeconds = actualSeconds + 1;
            }
        }
        if (countDown)
        {
            if (seconds <= 0 && actualSeconds > 0)
            {
                minutes--;
                seconds = 59;
                actualSeconds = actualSeconds - 1;
            }

        }
    }

    private void GameOver()
    {
        //scoreboardTable.AddHighscoreEntry(scoreTracker.score, scoreTracker.userName);
        //scoreBoard.SetActive(true);
        AudioManager.Instance.PlaySFX("GameOver(Test)");
        AudioManager.Instance.musicSource.Stop();
    }

    private void TimeOutAudio()
    {
        if(timeout == false)
        {
            if (hasLimit && ((countDown && actualSeconds <= limit + 11) || (!countDown && actualSeconds >= limit - 11)))
            {
                timeout = true;
                AudioManager.Instance.PlaySFX("Countdown(Test)");

            }
        }
    }
}
