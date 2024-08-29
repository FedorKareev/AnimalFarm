using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;
    private Slider _volumeSlider;

    private void Start()
    {
        float volume = _volumeSlider.value;
        _audioMixer.SetFloat("Master", volume);
    }
}
