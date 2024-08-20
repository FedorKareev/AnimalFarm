using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CheckPlacement : MonoBehaviour
{
    private BuildingSystem buildingSystem;
    private bool IsCollidersHere;
    [SerializeField]
    private Renderer MainRenderer;
    // Проверочная строка
    void Start()
    {
        buildingSystem = BuildingSystem.Instance;
    }

    public void SetTransparent(bool CanPlace)
    {
        if (CanPlace)
        {
            MainRenderer.material.color = Color.green;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }
    public void SetNormal()
    {
        MainRenderer.material.color = Color.white;
    }

    private void Update()
    {
        IsPlaceble();
        if (IsCollidersHere)
        {
            buildingSystem.CanPlace = false;
        }
        else
        {
            buildingSystem.CanPlace = true;
        }
    }

    
    private void IsPlaceble()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        IsCollidersHere = colliders.Length > 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
