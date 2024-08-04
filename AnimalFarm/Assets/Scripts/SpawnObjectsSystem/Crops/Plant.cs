using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private float _timeToMaturity;
    [SerializeField]
    private Mesh[] cropsStateMeshes;
    [SerializeField]
    private ItemData _itemData;
    public bool _isMaturing { get; private set; } = true;
    public ItemData ItemData
    {
        get
        {
            return _itemData;
        }
        set
        {
            ItemData = _itemData;
        }
    }

    private int _cropState = 0;
    private float elapsedTime;

    private void Update()
    {
        if (_isMaturing)
        {
            GrowCrop();
        }
    }
    private void GrowCrop()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _timeToMaturity / cropsStateMeshes.Length)
        {
            _cropState++;
            MeshFilter plantMesh = gameObject.GetComponentInChildren<MeshFilter>();
            plantMesh.mesh = cropsStateMeshes[_cropState];
            elapsedTime = 0;
        }
        else if (_cropState >= cropsStateMeshes.Length - 1)
        {
            _isMaturing = false;
        }
    }

    public float TakeMultiplier(float timeMultiplier = 1)
    {
        return _timeToMaturity = _timeToMaturity / timeMultiplier;
    }
}
