using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : AnimalBase
{
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

    protected void CollectPlants(Action onCollectPlants)
    {
        _gardenBed.CollectPlants();
        onCollectPlants?.Invoke();
    }

    public void CollectPlants()
    {
        _agent.enabled = true;
        AnimalMove(_target, () => CollectPlants(() => StartCoroutine(Timer(() => AnimalMove(startPosition, () => OnStartPosition())))));
    }
}
