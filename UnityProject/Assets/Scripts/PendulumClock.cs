using System;
using UnityEngine;

public class PendulumClock : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Transform pendulum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        double time = TimeManager.CurrentTime;
        double angle = -90 + 45 * Math.Sin(time * 2 * Math.PI * moveSpeed);
        pendulum.localRotation = Quaternion.Euler((float)angle, 90, 0);
    }
}
