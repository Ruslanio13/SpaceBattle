using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SFXSlider _sfxSlider;
    [SerializeField] private Slider _ostSlider;
    
    private void Start()
    {
        if(!PlayerPrefs.HasKey("SFX_Vol"))
            PlayerPrefs.SetFloat("SFX_Vol", 0.8f);
        if (!PlayerPrefs.HasKey("OST_Vol"))
            PlayerPrefs.SetFloat("OST_Vol", 0.8f);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFX_Vol");
        _ostSlider.value = PlayerPrefs.GetFloat("OST_Vol");
        
        GlobalMusic.Instance.SetVolume(_ostSlider.value);

        _sfxSlider.onValueChanged.AddListener((float newVol)=>
        {
            PlayerPrefs.SetFloat("SFX_Vol", newVol);
        });
        _ostSlider.onValueChanged.AddListener((float newVol)=>
        {
            PlayerPrefs.SetFloat("OST_Vol", newVol);
            GlobalMusic.Instance.SetVolume(newVol);
        });
        
    }
}
