using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Goods
{
    Tomato,
    Carrot,
    Gardenbed,
    GooseCoop
}
public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _goods;
    public void SpawnInRadius(Goods goods)
    {
        Instantiate(_goods[(int)goods], transform.position + new Vector3(Random.Range(5,0), transform.position.y, Random.Range(5, 0)), Quaternion.identity);
    }
}
