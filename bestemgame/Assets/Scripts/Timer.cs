using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Timer
{
    private float TimeToWait = 0f;
    private float TimeWaited = 0f;

    public void Set(float timeToWait)
    {
        TimeToWait = timeToWait;
        TimeWaited = 0f;
    }

    public void Reset()
    {
        TimeWaited = 0;
    }

    public bool Update()
    {
        if (TimeToWait > TimeWaited)
        {
            TimeWaited += Time.deltaTime;
            return false;
        }
        return true;

    }
    public bool HasEnded()
    {
        return TimeToWait <= TimeWaited;
    }
}
