using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{
    public float timer;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text timeScaleText;

    void Update()
    {
        timerText.text = ((int)timer).ToString();
        timeScaleText.text = Time.timeScale.ToString();
        timer = Time.time;
        if (timer > 20f && timer < 30f)
            Time.timeScale = 1.2f;
        if (timer >= 30f && timer < 40f)
            Time.timeScale = 1.4f;
        if (timer >= 40f && timer < 50f)
            Time.timeScale = 1.6f;
        if (timer >= 50f && timer < 60f)
            Time.timeScale = 2f;
    }
}
