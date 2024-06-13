using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public Slider volumeSlider;
    public bool isMusicVolume = true;

    void Start()
    {
        if (AudioManagement.instance != null)
        {
            volumeSlider.value = isMusicVolume ? AudioManagement.instance.musicSource.volume : AudioManagement.instance.effectsSource.volume;
        }

        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    public void OnVolumeChange(float value)
    {
        if (AudioManagement.instance != null)
        {
            if (isMusicVolume)
            {
                AudioManagement.instance.SetMusicVolume(value);
            }
            else
            {
                AudioManagement.instance.SetEffectsVolume(value);
            }
        }
    }
}
