using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : AnimalBase
{
    private void OnTriggerEnter(Collider collider)
    {
        GardenbedScript gardenBed = collider.gameObject.GetComponent<GardenbedScript>();
        if (gardenBed != null && gardenBed.IsSpawned)
        {
            gardenBed.CollectPlants();
        }
    }
    public void CollectPlants()
    {
        _agent.enabled = true;
        AnimalMove(_target, () => StartCoroutine(Timer(() => AnimalMove(_market, () => StartCoroutine(Timer(() => AnimalMove(startPosition, () => OnStartPosition())))))));
    }
    private void PlantCrops()
    {

    }
}
