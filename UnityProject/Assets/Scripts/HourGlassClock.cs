using System;
using UnityEngine;

public class HourGlassClock : MonoBehaviour
{
    [SerializeField] private Transform upSand;
    [SerializeField] private Transform downSand;
    
    private float upStartScale = 1f;
    private float upEndScale = 0f;
    
    private float downStartScale = 0f;
    private float downEndScale = 1f;


    private void FixedUpdate()
    {
        float time = TimeManager.UnwrappedTime * 5f; // [0..1]
        time = Mathf.Clamp01(time);

        upSand.localScale = new Vector3(
            upSand.localScale.x,
            Mathf.Lerp(upStartScale, upEndScale, time),
            upSand.localScale.z
            );
        
        downSand.localScale = new Vector3(
            downSand.localScale.x,
            Mathf.Lerp(downStartScale, downEndScale, time),
            downSand.localScale.z
        );
    }
}
