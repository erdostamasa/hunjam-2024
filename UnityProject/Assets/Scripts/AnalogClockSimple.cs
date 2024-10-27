using System;
using UnityEngine;

public class AnalogClockSimple : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hourPointer;
    [SerializeField] private Rigidbody2D minutePointer;

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

        // Calculate angular velocities
        float hourAngularVelocity = (hourAngle - hourPointer.rotation) / Time.fixedDeltaTime;
        float minuteAngularVelocity = (minuteAngle - minutePointer.rotation) / Time.fixedDeltaTime;

        // Debug.Log("Hour Angle: " + hourAngle + " Minute Angle: " + minuteAngle);
        // Debug.Log("Hour Angular Velocity: " + hourAngularVelocity + " Minute Angular Velocity: " + minuteAngularVelocity);

        // Apply angular velocities to the rigidbodies
        hourPointer.angularVelocity = hourAngularVelocity;
        minutePointer.angularVelocity = minuteAngularVelocity;
    }
}