using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private Transform spawnPlane;
    [SerializeField]
    private LayerMask ignorLayers;

    private float _delayTime = 50;
    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _delayTime)
        {
            InstansiateTrees();
            _timer = 0f;
        }
    }

    private void InstansiateTrees()
    {
        Vector3 spawnPos = SpawnRadius();
        if (!Physics.CheckSphere(spawnPos, 1f, ignorLayers))
        {
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 SpawnRadius()
    {
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(20, -20), transform.position.y, Random.Range(20, -20));
        return randomPosition;
    }
}
