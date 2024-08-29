using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSFX : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _enterButtonSound;
    [SerializeField]
    private AudioClip _clickButtonSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void EnterButtonSound()
    {
        _audioSource.PlayOneShot(_enterButtonSound);
    }

    public void ClickButtonSound()
    {
        _audioSource.PlayOneShot(_clickButtonSound);
    }
}
