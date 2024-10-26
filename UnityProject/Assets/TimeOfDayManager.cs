using Sydewa;
using UnityEngine;

public class TimeOfDayManager : MonoBehaviour
{
    [SerializeField] private LightingManager lightingManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var time = TimeManager.CurrentTime;
        lightingManager.TimeOfDay = (float)time * 24;
    }
}
