using System;
using UnityEngine;

public class ClickSoundManager : MonoBehaviour
{
    private static ClickSoundManager instance = null;

    public static ClickSoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ClickSoundManager>();
            }

            if (instance == null)
            {
                GameObject gObj = new GameObject();
                gObj.name = "MenuManager";
                instance = gObj.AddComponent<ClickSoundManager>();
                DontDestroyOnLoad(gObj);
            }

            return instance;
        }
    }
    
    [Header("Click sounds")] [SerializeField]
    private AudioSource source;

    [SerializeField] private float minVolume = 0f;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float volumeChangeSpeed = 1f;
    [SerializeField] private float targetSpeedScalar = 10f;
    private float targetVolume = 0;

    private void Update()
    {
        HandleClickSound();
    }

    private void HandleClickSound()
    {
        source.volume = Mathf.Lerp(source.volume, targetVolume, Time.deltaTime * volumeChangeSpeed);
        // Debug.Log($"volume: {source.volume} targetolume: {targetVolume}");
    }

    public void SetTargetVolume(float volume)
    {
        targetVolume = Mathf.Abs(volume) * targetSpeedScalar;
        Debug.Log($"targetvolume: {targetVolume}");
    }

    public void SetVolumeDirectly(float volume)
    {
        targetVolume = volume;
    }
}
