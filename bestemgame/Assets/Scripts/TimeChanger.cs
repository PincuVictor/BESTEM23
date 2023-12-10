using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{
    public float timer;
    public float timeRef;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text timeScaleText;

    private void Start()
    {
        timeRef = Time.time;
        Time.timeScale = 1f;
    }

    void Update()
    {
        timerText.text = ((int)(timer - timeRef)).ToString();
        timeScaleText.text = Time.timeScale.ToString();
        timer = Time.time;
        if (timer - timeRef > 20f && timer - timeRef < 30f)
            Time.timeScale = 1.2f;
        if (timer -timeRef >= 30f && timer - timeRef < 40f)
            Time.timeScale = 1.4f;
        if (timer - timeRef >= 40f && timer - timeRef < 50f)
            Time.timeScale = 1.6f;
        if (timer - timeRef >= 50f && timer - timeRef < 60f)
            Time.timeScale = 2f;
    }
}
