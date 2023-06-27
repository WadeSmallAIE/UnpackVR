using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [Header("Time Settings")]
    [SerializeField] private float seconds;
    [SerializeField] private float minutes;
    [SerializeField] private bool countDown;
    [SerializeField] private bool hasLimit;
    [SerializeField] private float limit;
    [Header("Debug")]
    [SerializeField] private float actualSeconds;

    void Start()
    {
        actualSeconds = seconds + (minutes * 60);
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
        }

        DisplayTime();
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

}
