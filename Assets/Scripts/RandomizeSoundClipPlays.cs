using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class RandomizeSoundClipPlays : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clips;

    public bool playOnAwake = true;
    public bool isSummons = false;
    
    private void OnEnable()
    {
        if(playOnAwake)
            StartAudio();
    }

    public void StartAudio()
    {
        if (isSummons && SceneManager.GetActiveScene().name.Equals("Human"))
            return;
        
        audioSource.clip = clips[Random.Range(0, clips.Count)];
        audioSource.Play();
    }
}
