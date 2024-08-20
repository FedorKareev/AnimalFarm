using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CheckPlacement : MonoBehaviour
{
    private BuildingSystem _buildingSystem;
    private bool _isCollidersHere;
    [SerializeField]
    private Renderer _mainRenderer;
    [SerializeField]
    private float _radius;
    void Start()
    {
        _buildingSystem = BuildingSystem.Instance;
    }

    public void SetTransparent(bool CanPlace)
    {
        if (CanPlace)
        {
            _mainRenderer.material.color = Color.green;
        }
        else
        {
            _mainRenderer.material.color = Color.red;
        }
    }
    public void SetNormal()
    {
        _mainRenderer.material.color = Color.white;
    }

    private void Update()
    {
        IsPlaceble();
        if (_isCollidersHere)
        {
            _buildingSystem.CanPlace = false;
        }
        else
        {
            _buildingSystem.CanPlace = true;
        }
    }

    
    private void IsPlaceble()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        _isCollidersHere = colliders.Length > 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
