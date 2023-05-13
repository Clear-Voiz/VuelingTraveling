using System;
using UnityEngine;

public struct Timers
{
    public float[] alarm;

    public Timers(int length)
    {
        alarm = new float[length];
        for(int i = 0;i<length;i++)
        {
            alarm[i] = 0f;
        }
    }

    public float Timer(float duration, float currentTime, Action act)
    {
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                currentTime = 0;
                act();
            }
        }

        return currentTime;
    }
    
    public float Timer<T>(float duration, float currentTime, Action<T> act,T thing)
    {
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                currentTime = duration;
                act(thing);
            }
        }

        return currentTime;
    }
    
    public float Cicle<T>(float duration, float currentTime, Action<T> act, T thing)
    {
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                currentTime = 0f;
                act(thing);
            }
        }

        return currentTime;
    }
    
    public float Cicle<T>(float duration, float currentTime, Action<T> act, T thing, ref int repetitions)
    {
        if (repetitions < 1) return currentTime;
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                repetitions--;
                currentTime = 0f;
                act(thing);
            }
        }

        return currentTime;
    }
    
    /*public float Timer<T>(float duration, Action<T> act)
    {
        if (duration > 0f)
        {
            duration -= Time.deltaTime;

            if (duration <= 0f)
            {
                act(T);
                duration = 0f;
            }
        }

        return duration;
    }*/

    
    public float Chronometer(float duration, float currentTime, Action constAct)
    {
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
            {
                currentTime = duration;
            }
            constAct();
        }
        
        return currentTime;
    }

    public float Timer(float duration, float currentTime)
    {
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
            {
                currentTime = duration;
            }
        }
        
        return currentTime;
    }
}
