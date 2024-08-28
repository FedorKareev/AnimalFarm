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
    [field: SerializeField]
    public ItemData itemData { get; set; }

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip _plantSound;
    [SerializeField]
    private AudioClip _collectSound;
    [SerializeField]
    private AudioClip _digPlantSound;

    private bool isAbleToOpen;
    private GameObject _plantedObject;
    private Plant rightPlant;
    private float _timeMultiplierByUpgrade = 1;
    private AudioSource _audioSource;


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
    }

    private void OnMouseDown()
    {
        vegetableSelectionMenu.SetActive(true);
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
        StartCoroutine(CollectPlantsEnumerator());
    }
    private IEnumerator CollectPlantsEnumerator()
    {
        yield return new WaitForSeconds(TIMEFOR_COLLECT);
        if (_plantedObject != null && !_plantedObject.GetComponent<Plant>()._isMaturing)
        {
            _plantedObject.GetComponent<Plant>().ItemData.Amount++;
            _timeMultiplier = _timeMultiplierByUpgrade;
            DigVegetable();
            _audioSource.PlayOneShot(_collectSound);
        }
        else
        {
            Debug.Log("������ �� ���������");
        }
    }

    public void ChangeMultiplierByFertilizers(float multiplier)
    {
        _timeMultiplier += multiplier;
    }
    public void ChangeMultiplierByUpgrade(float multiplier)
    {
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

    public void DestroyBuilding()
    {
        itemData.Amount++;
        Destroy(gameObject);
    }
}
