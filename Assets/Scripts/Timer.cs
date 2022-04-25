using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    private float timerRemaining = 5;
    private bool timerIsRunning = false;
    [SerializeField] private TextMeshProUGUI timerTxt;
    public float timeRemaining
    {
        get => timerRemaining;
        set => timerRemaining = value;
    } 
    void Awake()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timerRemaining > 0)
            {
                timerRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timerRemaining = 0;
                timerIsRunning = false;
            }
        }

        DisplayTime(timerRemaining);
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
