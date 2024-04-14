using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider mainVolSlider;
    [SerializeField] private Slider musicVolSlider;
    [SerializeField] private Slider effectsVolSlider;
    
    private void Start()
    {
        LoadAudio();
    }

    private void LoadAudio()
    {
        Assert.IsTrue(mainVolSlider && musicVolSlider  && effectsVolSlider, 
            "No audio slider in MainMenuUIManager");
        
        float mainVolLvl = PlayerPrefs.GetFloat("MainVolume", 0.75f);
        float musicVolLvl = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float effectsVolLvl = PlayerPrefs.GetFloat("SoundEffectsVolume", 0.50f);
        
        mainVolSlider.value = mainVolLvl;
        musicVolSlider.value = musicVolLvl;
        effectsVolSlider.value = effectsVolLvl;
        
        audioMixer.SetFloat ("MainVolume", Mathf.Log10(mainVolLvl) * 20);
        audioMixer.SetFloat ("MusicVolume", Mathf.Log10(musicVolLvl) * 20);
        audioMixer.SetFloat ("SoundEffectsVolume", Mathf.Log10(effectsVolLvl) * 20);
    }

    public void SetMainVolumeLevel(float mainVolLvl)
    {
        audioMixer.SetFloat ("MainVolume", Mathf.Log10(mainVolLvl) * 20);
        PlayerPrefs.SetFloat("MainVolume", mainVolLvl);
    }

    public void SetMusicVolumeLevel(float musicVolLvl)
    {
        audioMixer.SetFloat ("MusicVolume", Mathf.Log10(musicVolLvl) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolLvl);
    }
    
    public void SetEffectsVolumeLevel(float effectsVolLvl)
    {
        audioMixer.SetFloat ("SoundEffectsVolume", Mathf.Log10(effectsVolLvl) * 20);
        PlayerPrefs.SetFloat("SoundEffectsVolume", effectsVolLvl);
    }

}
