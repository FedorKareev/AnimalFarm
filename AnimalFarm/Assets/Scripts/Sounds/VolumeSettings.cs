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

    private void LoadVolume()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat("Master");
        _musicVolumeSlider.value = PlayerPrefs.GetFloat("Music");

        SetMasterVolume();
        SetMusicVolume();
    }
}
