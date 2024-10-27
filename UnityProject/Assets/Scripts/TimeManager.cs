using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance = null;

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimeManager>();
            }

            if (instance == null)
            {
                GameObject gObj = new GameObject();
                gObj.name = "MenuManager";
                instance = gObj.AddComponent<TimeManager>();
                DontDestroyOnLoad(gObj);
            }

            return instance;
        }
    }

    [SerializeField] private float timeRewindSpeed = 0.2f;

    public static double CurrentTime { private set; get; }

    public static float UnwrappedTime { private set; get; }

    public static float UnClampedTime { private set; get; }

    private void OnEnable()
    {
        EventManager.onPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDeath -= HandlePlayerDeath;
    }

    public static void ResetTime()
    {
        CurrentTime = 0.5;
        UnwrappedTime = 0f;
        UnClampedTime = 0.5f;
    }

    public void AddTime(double change)
    {
        // CurrentTime
        CurrentTime = ConstrainTime(CurrentTime + change);

        // UnwrappedTime
        // UnwrappedTime += (float)change;
        // UnwrappedTime = Mathf.Clamp(UnwrappedTime, 0, 0.2f); // homokóra *5 speeden megy 
        UnwrappedTime = UnWrapTime(UnwrappedTime + (float)change);

        // Unclamped Time
        UnClampedTime += (float)change;
    }

    private float UnWrapTime(float newTime)
    {
        float result = newTime;
        result = Mathf.Clamp(result, 0, 0.2f); // homokóra *5 speeden megy 
        return result;
    }

    private double ConstrainTime(double newTime)
    {
        double result = 0f;
        double fraction = Math.Abs(newTime - Math.Truncate(newTime));
        if (newTime < 0.0)
        {
            result = 1 - fraction;
        }
        else
        {
            result = fraction;
        }

        return result;
    }

    private void HandlePlayerDeath()
    {
        StartCoroutine(RewindTime());
    }

    IEnumerator RewindTime()
    {
        PlayerControls.Instance.gameObject.SetActive(false);
        ClickSoundManager.Instance.SetVolumeDirectly(1f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Set a small threshold to account for float precision issues
        const float targetTime = 0.5f;
        const float precision = 0.001f;

        while (Mathf.Abs(UnClampedTime - targetTime) > precision)
        {
            float diff = Mathf.Abs(UnClampedTime - targetTime);
            float scalar = Mathf.Max(diff, 0.05f);
        
            // Choose direction based on whether UnClampedTime is above or below 0.5
            float direction = UnClampedTime > targetTime ? -1f : 1f;
            AddTime(direction * timeRewindSpeed * Time.deltaTime * scalar);
        
            yield return null;
        }

        ResetTime();

        ClickSoundManager.Instance.SetVolumeDirectly(0f);
        PlayerControls.Instance.gameObject.SetActive(true);

    }
}