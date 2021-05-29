using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        PlayerPrefsController.SetMasterVolume(0.2f);
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        DontDestroyOnLoad(this);        
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
