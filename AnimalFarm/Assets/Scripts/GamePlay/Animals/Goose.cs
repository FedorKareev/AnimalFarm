using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : AnimalBase
{
    private bool _isCollecting;

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

    private void OnTriggerEnter(Collider collider)
    {
        GardenbedScript gardenBed = collider.gameObject.GetComponent<GardenbedScript>();
        if (gardenBed != null && gardenBed.IsSpawned && _isCollecting)
        {
            gardenBed.CollectPlants();
        }
    }
    public void CollectPlants()
    {
        _isCollecting = true;
        _agent.enabled = true;
        AnimalMove(_target, () => StartCoroutine(Timer(() => StartCoroutine(Timer(() => AnimalMove(startPosition, () => OnStartPosition()))))));
    }
}
