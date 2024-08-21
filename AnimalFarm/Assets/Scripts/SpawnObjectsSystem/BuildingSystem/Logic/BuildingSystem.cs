using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildingSystem : SpawnObjectsBase
{
    public static BuildingSystem Instance;

    private Vector3 pos;
    private RaycastHit hit;
    private GameObject pendingObject;

    [SerializeField]
    private float gridSize;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private GameObject[] buildings;
    [SerializeField]
    private int rotateDigrees;

    public bool CanPlace { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CanPlace = true;
    }
    void Update()
    {
        SpawnObject();
    }

    public void PlaceObject()
    {
        pendingObject.GetComponent<CheckPlacement>().SetNormal();
        pendingObject.GetComponent<CheckPlacement>().enabled = false;
        pendingObject = null;
        IsSpawned = false;
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int rayDistance = 1000;

        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            pos = hit.point;
        }
    }
    private void ResetPendingObject()
    {
        Destroy(pendingObject);
        IsSpawned = false;
    }
    private void RotateObjects()
    {
        pendingObject.transform.Rotate(0, rotateDigrees, 0);
    }

    public override void SelectObject(int index)
    {
        pendingObject = Instantiate(buildings[index], pos, transform.rotation);
        IsSpawned = true;
    }

    private void SpawnObject()
    {
        if (pendingObject != null)
        {
            pendingObject.transform.position = new Vector3(
                RoundToNearestGrid(pos.x),
                RoundToNearestGrid(pos.y),
                RoundToNearestGrid(pos.z));
            pendingObject.GetComponent<CheckPlacement>().SetTransparent(CanPlace);

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObjects();
            }
            if (Input.GetMouseButton(0) && CanPlace)
            {
                Debug.Log("Это метод спавна");
                PlaceObject();
            }
        }
    }

    private float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
