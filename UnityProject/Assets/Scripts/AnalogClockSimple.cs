using System;
using UnityEngine;

public class AnalogClockSimple : MonoBehaviour
{
    [SerializeField] private Transform hourPointer;
    [SerializeField] private Transform minutePointer;
    
    private void FixedUpdate()
    {
        // Calculate hours and minutes as if on a 12-hour clock
        double currentTime = TimeManager.CurrentTime;
        
        double totalHours = currentTime * 12; // scales current time to a 12-hour period
        double hours = Math.Floor(totalHours); // integer hour value
        double minutes = (totalHours - hours) * 60; // remaining fraction of the hour in minutes

        // Calculate the angles for the hour and minute hands
        float hourAngle = (float)(hours * 30 + minutes * 0.5); // 30 degrees per hour + 0.5 degrees per minute
        float minuteAngle = (float)(minutes * 6); // 6 degrees per minute

        // Apply the rotation
        hourPointer.localRotation = Quaternion.Euler(-hourAngle, 0, 0);
        minutePointer.localRotation = Quaternion.Euler(-minuteAngle, 0, 0);
    }
}
