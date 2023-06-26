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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds = countDown ? seconds -= Time.deltaTime : seconds += Time.deltaTime;

        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;       
        }

        if (hasLimit && ((countDown && seconds <= limit) || (!countDown && seconds >= limit))) 
        {
            seconds = limit;
            DisplayTime();
            text.color = Color.red;
            enabled = false;
        }

        DisplayTime();
    }

    private void DisplayTime()
    {
        

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //text.text = time.ToString();
    }
}
