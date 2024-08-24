using System;
using System.Collections;
using UnityEngine;

public class GardenbedScript : SpawnObjectsBase, IDestroyer
{
    public const int TIMEFOR_COLLECT = 5;

    [SerializeField]
    protected GameObject[] objectsToSpawn;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField, Min(1f)]
    private float _timeMultiplier;
    [SerializeField]
    private GameObject vegetableSelectionMenu;
    [field: SerializeField]
    public ItemData itemData { get; set; }

    private bool isAbleToOpen;
    private GameObject _plantedObject;
    private Plant rightPlant;

    public static event Action onSpawn;

    private void Start()
    {
        DigVegetable();
        onSpawn?.Invoke();
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
            }
        }
    }
    public void DigVegetable()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (IsSpawned == true)
            {
                Destroy(spawnPoints[i].GetChild(0).gameObject);
            }
        }
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(objectsToSpawn[0], spawnPoints[i].position, Quaternion.identity, spawnPoints[i]);
            IsSpawned = false;
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
            _timeMultiplier = 1;
            DigVegetable();
        }
        else
        {
            Debug.Log("Ничего не посаженно");
        }
    }

    public void ChangeMultiplier(float multiplier)
    {
        _timeMultiplier = multiplier;
    }
    public void DestroyBuilding()
    {
        itemData.Amount++;
        Destroy(gameObject);
    }
}
