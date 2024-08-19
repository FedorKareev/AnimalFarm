using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DuckСoop : MonoBehaviour
{
    [SerializeField]
    private List<AnimalBase> _ducks = new List<AnimalBase>();
    [SerializeField]
    private GardenbedScript[] _gardenBeds;

    private void OnEnable()
    {
        GardenbedScript.onSpawn += AddTargets;
    }
    private void OnDisable()
    {
        GardenbedScript.onSpawn -= AddTargets;
    }
    private void AddTargets()
    {
        _gardenBeds = GameObject.FindObjectsOfType<GardenbedScript>();
    }
    private void OnMouseDown()
    {
        MoveAnimals();
        Debug.Log("Кнопка нажата");
    }
    private void MoveAnimals()
    {
        if (_gardenBeds.Length != 0)
        {
            for (int i = 0; i < _ducks.Count; i++)
            {
                _ducks[i].Target = _gardenBeds[UnityEngine.Random.Range(0, _gardenBeds.Length)].transform;
                _ducks[i].StartPosition = gameObject.transform;
                _ducks[i].IsMoveSwitcher();
            }
        }
    }
}
