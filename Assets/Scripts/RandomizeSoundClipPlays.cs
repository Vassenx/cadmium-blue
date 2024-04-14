using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomizeSoundClipPlays : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clips;

    public bool playOnAwake = true;
    
    private void Start()
    {
        if(playOnAwake)
            StartAudio();
    }

    public void StartAudio()
    {
        audioSource.clip = clips[Random.Range(0, clips.Count)];
        audioSource.Play();
    }
}
