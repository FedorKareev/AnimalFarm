using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ITEM_TEST : MonoBehaviour
{
    [SerializeField]
    private int amount;
    [SerializeField]
    private ItemData itemTest;

    private AudioSource _audioSource;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _pickUpAudio;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Saller player = other.GetComponent<Saller>();
        if (player != null)
        {
            _audioSource.PlayOneShot(_pickUpAudio);
            itemTest.Amount += amount;
            Destroy(gameObject);
        }
    }
}
