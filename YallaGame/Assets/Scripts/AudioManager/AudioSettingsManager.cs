using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer; // connect your AudioMixer here
    public Slider volumeSlider;   // connect the Slider here

    void Start()
    {
        // Add the volume change listener
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        // Convert the slider value (0..1) to decibels (-80..0)
        float dB = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20;
        audioMixer.SetFloat("MusicVolume", dB);
    }
}