using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer; // подключим сюда наш микшер
    public Slider volumeSlider;   // подключим слайдер

    void Start()
    {
        // Установим значение слайдера в начало (например, -20 dB = 0.5f)
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        // Преобразуем значение слайдера (0..1) в децибелы (-80..0)
        float dB = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20;
        audioMixer.SetFloat("MusicVolume", dB);
    }
    


}
