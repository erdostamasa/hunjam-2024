using System;
using UnityEngine;

public static class TimeManager
{
    public static double CurrentTime { private set; get; }

    public static float UnwrappedTime { private set; get; }

    public static void ResetTime()
    {
        CurrentTime = 0.5;
        UnwrappedTime = 0f;
    }

    public static void AddTime(double change)
    {
        // CurrentTime
        double newTime = CurrentTime + change;
        double fraction = Math.Abs(newTime - Math.Truncate(newTime));
        if (newTime < 0.0)
        {
            CurrentTime = 1 - fraction;
        }
        else
        {
            CurrentTime = fraction;
        }

        // UnwrappedTime
        UnwrappedTime += (float)change;
        UnwrappedTime = Mathf.Clamp(UnwrappedTime, 0, 0.2f); // homokóra *5 speeden megy 
    }
}
