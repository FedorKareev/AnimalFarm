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
        if (IsPlayerHere())
        {
            gameObject.GetComponent<GardenbedScript>().IsAbleToOpen = true;
        }
        else
        {
            gameObject.GetComponent<GardenbedScript>().IsAbleToOpen = false;
        }
    }

    
    private void IsPlaceble()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        IsCollidersHere = colliders.Length > 2;
    }
    public bool IsPlayerHere()
    {
        bool isPlayerHere = Physics.BoxCast(transform.position, new Vector3(12,12,12), Vector3.up, transform.rotation, 25, 10);
        return isPlayerHere;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4f);
        Gizmos.DrawCube(transform.position, new Vector3(12, 12, 12));
    }
}
