using System;
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
    public GameObject badEndingScreen;
    public static event Action OnTimerCompleted;
    private bool isEnabled;

    private void OnEnable()
    {
        Dialogue.StartTimer += EnableTimer;
    }
    private void OnDisable()
    {
        Dialogue.StartTimer -= EnableTimer;
    }

    private void Update()
    {
        if (isEnabled)
        {
            if (timeLeft > 0f)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0f)
                {
                    OnTimerCompleted?.Invoke();
                    AudioManager.instance.musicSource.Stop();
                    AudioManager.instance.PlaySFX("TimesUp");
                    badEndingScreen.SetActive(true);
                    Destroy(gameObject);
                }
                DisplayTime(timeLeft);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        readout.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EnableTimer()
    {
        isEnabled = true;
    }
}
