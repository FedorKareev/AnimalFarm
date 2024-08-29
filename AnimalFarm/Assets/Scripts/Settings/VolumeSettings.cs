using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Slider _masterVolumeSlider;
    [SerializeField]
    private Slider _musicVolumeSlider;
    [SerializeField]
    private Slider _SFXVolumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Master"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMasterVolume()
    {
        float volume = _masterVolumeSlider.value;
        _audioMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Master", volume);
    }

    public void SetMusicVolume()
    {
        float volume = _musicVolumeSlider.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);
    }
    public void SetSFXVolume()
    {
        float volume = _SFXVolumeSlider.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
    }

    private void LoadVolume()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat("Master");
        _musicVolumeSlider.value = PlayerPrefs.GetFloat("Music");
        _SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFX");

        SetSFXVolume();
        SetMasterVolume();
        SetMusicVolume();
    }
}
