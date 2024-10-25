using System;
using UnityEngine;

public static class TimeManager
{
    public static double CurrentTime { private set; get; }

    public static void ResetTime()
    {
        CurrentTime = 0.5;
    }

    public static void AddTime(double change)
    {
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

        // Debug.Log($"CurrentTime: {CurrentTime}");
    }

}
