using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _footSteps;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void FootStepsOn()
    {
        _audioSource.PlayOneShot(_footSteps[Random.Range(0, _footSteps.Length)]);
    }
}
