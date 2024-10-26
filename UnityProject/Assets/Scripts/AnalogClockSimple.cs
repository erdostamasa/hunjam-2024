using System;
using UnityEngine;

public class AnalogClockSimple : MonoBehaviour
{
    [SerializeField] private Transform hourPointer;
    [SerializeField] private Transform minutePointer;
    
    // Rotation axes for hour and minute pointers
    [SerializeField] private Vector3 hourRotationAxis = Vector3.forward;
    [SerializeField] private Vector3 minuteRotationAxis = Vector3.forward;

    private float baseHourRotation;
    private float baseMinuteRotation;

    private void Start()
    {
        // Initialize base rotations from the rotation of each pointer around the specified axis
        baseHourRotation = Vector3.Project(hourPointer.localRotation.eulerAngles, hourRotationAxis).magnitude;
        baseMinuteRotation = Vector3.Project(minutePointer.localRotation.eulerAngles, minuteRotationAxis).magnitude;
    }

    private void FixedUpdate()
    {
        // Assuming TimeManager.CurrentTime is a value between 0.0 and 1.0 representing the time of day
        double currentTime = TimeManager.CurrentTime;
        
        // Calculate hours and minutes as if on a 12-hour clock
        double totalHours = currentTime * 12; // scales current time to a 12-hour period
        double hours = Math.Floor(totalHours); // integer hour value
        double minutes = (totalHours - hours) * 60; // remaining fraction of the hour in minutes

        // Calculate the angles for the hour and minute hands
        float hourAngle = (float)(hours * 30 + minutes * 0.5); // 30 degrees per hour + 0.5 degrees per minute
        float minuteAngle = (float)(minutes * 6); // 6 degrees per minute

        // Apply the rotation, factoring in the base rotations and rotation axes
        hourPointer.localRotation = Quaternion.AngleAxis(-hourAngle + baseHourRotation, hourRotationAxis);
        minutePointer.localRotation = Quaternion.AngleAxis(-minuteAngle + baseMinuteRotation, minuteRotationAxis);
    }
}