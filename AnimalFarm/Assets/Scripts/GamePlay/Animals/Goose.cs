using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : AnimalBase
{
    private bool _isCollecting;

    private GardenbedScript _gardenBed;

    public GardenbedScript GardenBed
    {
        get
        {
            return _gardenBed;
        }
        set
        {
            _gardenBed = value;
        }
    }

    public ItemData Animal
    {
        get
        {
            return _animal;
        }
        set
        {
            _animal = value;
        }
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    GardenbedScript gardenBed = collider.gameObject.GetComponent<GardenbedScript>();
    //    if (gardenBed != null && gardenBed.IsSpawned && _isCollecting)
    //    {
    //        gardenBed.CollectPlants();
    //    }
    //}

    protected void CollectPlants(Action onCollectPlants)
    {
        _gardenBed.CollectPlants();
        onCollectPlants?.Invoke();
    }

    public void CollectPlants()
    {
        _isCollecting = true;
        _agent.enabled = true;
        AnimalMove(_target, () => CollectPlants(() => StartCoroutine(Timer(() => AnimalMove(startPosition, () => OnStartPosition())))));
    }
}
