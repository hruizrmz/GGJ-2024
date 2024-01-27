using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text readout;
    public float timeLeft;

    public UnityEvent onTimerCompleted;

    private void Update()
    {
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                onTimerCompleted?.Invoke();
                timeLeft = 0f;
                this.enabled = false;


            }

            DisplayTime(timeLeft);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        readout.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
