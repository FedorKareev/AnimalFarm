using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GardenbedScript : SpawnObjectsBase, IDestroyer
{
    public const int TIMEFOR_COLLECT = 5;
    public static Action onSpawn;

    [SerializeField]
    protected GameObject[] objectsToSpawn;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField, Min(1f)]
    private float _timeMultiplier;
    [SerializeField]
    private GameObject vegetableSelectionMenu;
    [SerializeField]
    private TextMeshPro _multiplierAmount;
    [SerializeField]
    private LayerMask _playerLayer;
    [field: SerializeField]
    public ItemData itemData { get; set; }

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip _plantSound;
    [SerializeField]
    private AudioClip _collectSound;
    [SerializeField]
    private AudioClip _digPlantSound;
    [SerializeField]
    private AudioClip _upgradeSound;

    private bool isAbleToOpen;
    private GameObject _plantedObject;
    private Plant rightPlant;
    private float _timeMultiplierByUpgrade = 1;
    private AudioSource _audioSource;
    private bool _isPlayerHere;

    public float TimeMultipleir
    {
        get
        {
            return _timeMultiplier;
        }
    }

    private void Start()
    {
        SetHoles();
        onSpawn?.Invoke();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _multiplierAmount.text = $"{Mathf.Floor(_timeMultiplier * 100) / 100}X";
        CheckIsPlayerHere();
        if (_isPlayerHere)
        {
            isAbleToOpen = true;
        }
        else
        {
            isAbleToOpen = false;
            vegetableSelectionMenu.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (isAbleToOpen)
        {
            vegetableSelectionMenu.SetActive(true);
        }
    }

    public override void SelectObject(int Index)
    {

        if (IsSpawned == false)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (spawnPoints[i].childCount > 0)
                {
                    Destroy(spawnPoints[i].GetChild(0).gameObject);
                }
            }

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                _plantedObject = Instantiate(objectsToSpawn[Index], spawnPoints[i].position, Quaternion.identity, spawnPoints[i]);
                _plantedObject.GetComponent<Plant>().TakeMultiplier(_timeMultiplier);
                IsSpawned = true;
                _audioSource.PlayOneShot(_plantSound);
            }
        }
    }

    private void SetHoles()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(objectsToSpawn[0], spawnPoints[i].position, Quaternion.identity, spawnPoints[i]);
            IsSpawned = false;
        }
    }

    public void DigVegetable()
    {
        if (IsSpawned == true)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Destroy(spawnPoints[i].GetChild(0).gameObject);
            }
            SetHoles();
            _audioSource.PlayOneShot(_digPlantSound);
        }
    }
    public void CollectPlants()
    {
        if (_plantedObject != null)
        {
            _plantedObject.GetComponent<Plant>().ItemData.Amount++;
            _timeMultiplier = _timeMultiplierByUpgrade;
            DigVegetable();
            _audioSource.PlayOneShot(_collectSound);
        }
        else
        {
            Debug.Log("Ничего не посаженно");
        }
    }

    public void ChangeMultiplierByFertilizers(float multiplier)
    {
        _timeMultiplier += multiplier;
    }
    public void ChangeMultiplierByUpgrade(float multiplier)
    {
        _audioSource.PlayOneShot(_upgradeSound);
        _timeMultiplierByUpgrade += multiplier;
        _timeMultiplier = _timeMultiplierByUpgrade;
    }

    public bool GetIsMaturing()
    {
        if (_plantedObject != null)
        {
            return _plantedObject.GetComponent<Plant>()._isMaturing;
        }
        else
        {
            return true;
        }
    }

    private void CheckIsPlayerHere()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(6,14,8),Quaternion.identity, _playerLayer);
        _isPlayerHere = colliders.Length > 0;
    }

    public void DestroyBuilding()
    {
        itemData.Amount++;
        Destroy(gameObject);
    }
}
