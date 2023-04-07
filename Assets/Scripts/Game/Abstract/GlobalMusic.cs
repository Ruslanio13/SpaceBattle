using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GlobalMusic : MonoBehaviour
{
    private AudioSource _audioSource;
    public static GlobalMusic Instance;
    
    private void Awake()
    {
        if (Instance is null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float newVolume)
    {
        _audioSource.volume = newVolume;
    }
}
