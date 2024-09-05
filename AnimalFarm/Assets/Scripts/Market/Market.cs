using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _itemDatas = new List<ItemData>();
    [SerializeField]
    private GameObject _marketUI;
    [SerializeField]
    private Money _money;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip _sallSound;

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Saller saller = other.GetComponent<Saller>();
        if (saller != null)
        {
            _marketUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Saller saller = other.GetComponent<Saller>();
        if (saller != null)
        {
            _marketUI.SetActive(false);
        }
    }

    public void Sall(ItemData itemData)
    {
        if (itemData.Amount > 0)
        {
            _money._amount += itemData.PriceForSell;
            itemData.Amount--;
            _audioSource.PlayOneShot(_sallSound);
        }
    }
}
