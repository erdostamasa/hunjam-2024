using System;
using UnityEngine;

public class PendulumClock : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Transform pendulum;
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private float startTime;



    // Update is called once per frame
    void Update()
    {
        double time = TimeManager.CurrentTime;
        double angle = 90 + 45 * Math.Sin((startTime + time) * 2 * Math.PI * moveSpeed + Math.PI / 2);
        pendulum.localRotation = Quaternion.AngleAxis(-(float)angle, rotationAxis);
    }
}
