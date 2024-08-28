using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    [SerializeField]
    private GameObject LaptopUI;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip _buySound;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        LaptopButton.OnBuySound += PlayBuySound;
    }
    private void OnDisable()
    {
        LaptopButton.OnBuySound -= PlayBuySound;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        LaptopUI.SetActive(true);
    }

    private void PlayBuySound()
    {
        _audioSource.PlayOneShot(_buySound);
    }

}
