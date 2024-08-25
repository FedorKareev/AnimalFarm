using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб, который нужно спавнить
    public Transform spawnPlane; // Плоскость, на которой будет происходить спавн
    public float spawnRadius = 5f;
    private float _delayTime = 10;
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
        if (!Physics.CheckSphere(spawnPos, 0.5f))
        {
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 SpawnRadius()
    {
        Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
        randomPosition = spawnPlane.position + randomPosition;
        randomPosition.y = spawnPlane.position.y;

        return randomPosition;
    }
}
