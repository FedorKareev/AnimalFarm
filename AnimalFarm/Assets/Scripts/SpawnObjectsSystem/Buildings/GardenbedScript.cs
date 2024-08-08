using System;
using System.Collections;
using UnityEngine;

public class GardenbedScript : SpawnObjectsBase
{
    public const int TIMEFOR_COLLECT = 3;

    [SerializeField]
    protected GameObject[] objectsToSpawn;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField, Min(1f)]
    private float _timeMultiplier;
    [SerializeField]
    private GameObject vegetableSelectionMenu;

    private GameObject _plantedObject;
    private Plant rightPlant;

    public static event Action onSpawn;

    private void OnMouseDown()
    {
        vegetableSelectionMenu.SetActive(true);
    }
    private void Start()
    {
        DigVegetable();
        onSpawn?.Invoke();
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
        if (!_plantedObject.GetComponent<Plant>()._isMaturing && _plantedObject != null)
        {
            _plantedObject.GetComponent<Plant>().ItemData.Amount += 1;
            DigVegetable();
        }
        else
        {
            Debug.Log("Не созрело");
        }
    }
}
