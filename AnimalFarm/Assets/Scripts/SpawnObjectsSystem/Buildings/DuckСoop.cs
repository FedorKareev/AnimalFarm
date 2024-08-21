using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DuckСoop : MonoBehaviour
{
    [SerializeField]
    private List<AnimalBase> _gooses = new List<AnimalBase>();
    [SerializeField]
    private GardenbedScript[] _gardenBeds;
    [SerializeField]
    private Market _market;
    [SerializeField]
    private GameObject _gooseCoopPanel;
    [SerializeField]
    private GameObject _goose;

    private void Start()
    {
        _gardenBeds = FindObjectsOfType<GardenbedScript>();
        _market = FindObjectOfType<Market>();
    }

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
        _gardenBeds = FindObjectsOfType<GardenbedScript>();
    }
    public void SpawnGooses()
    {
        GameObject goose = Instantiate(_goose, transform.position + new Vector3(Random.Range(5, 0), transform.position.y, Random.Range(5, 0)), Quaternion.identity);
        _gooses.Add(goose.GetComponent<AnimalBase>());
    }
    private void OnMouseDown()
    {
        _gooseCoopPanel.SetActive(true);
    }
    public void MoveAnimals()
    {
        if (_gardenBeds.Length != 0)
        {
            for (int i = 0; i < _gooses.Count; i++)
            {
                _gooses[i].Target = _gardenBeds[UnityEngine.Random.Range(0, _gardenBeds.Length)].transform;
                _gooses[i].Market = _market.transform;
                _gooses[i].StartPosition = gameObject.transform;
                _gooses[i].IsMoveSwitcher();
            }
        }
    }
}
