using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource soundSource;

    private void Awake()
    {
        EventManager.onPlayerDeath += PlayDeathSound;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    PlayDeathSound();
        //}
    }

    private void PlayDeathSound()
    {
        PlayClipWithVolume(deathSound, 0.2f, 0.05f, 1f, 0.1f);
    }

    public void PlayClipWithVolume(AudioClip clip, float volume, float volumeRandomization, float pitch,
        float pitchRandomization)
    {
        soundSource.clip = clip;
        soundSource.volume = volume + Random.Range(-volumeRandomization, volumeRandomization);
        soundSource.pitch = pitch + Random.Range(-pitchRandomization, pitchRandomization);
        soundSource.Play();
    }
}