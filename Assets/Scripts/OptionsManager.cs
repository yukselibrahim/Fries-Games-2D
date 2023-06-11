using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsManager : MonoBehaviour
{

    [SerializeField] Toggle mute;
    [SerializeField] Toggle Windowed;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeText;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Mute"))
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
        else
        {
            LoadMuteToggel();
        }

        if (!PlayerPrefs.HasKey("Windowed"))
        {
            PlayerPrefs.SetInt("Windowed", 0);
        }
        else
        {
            WindowedToggel();
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        LoadVolume();
    }

    public void WindowedToggel()
    {
        PlayerPrefs.SetInt("Windowed", Windowed.isOn ? 1 : 0);

        if (!Windowed.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void LoadWindowedToggel()
    {
        Windowed.isOn = PlayerPrefs.GetInt("Windowed") == 1;
    }

    private void LoadMuteToggel()
    {
        mute.isOn = PlayerPrefs.GetInt("Mute") == 1;
    }

    public void MuteToggle()
    {
        PlayerPrefs.SetInt("Mute", mute.isOn ? 1 : 0);

        if (mute.isOn)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    private void LoadVolume()
    {
        float volumeValue =PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void VolumeControl(float volume)
    {
        volumeText.text = "Volume " + volume.ToString("0");
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }
}
