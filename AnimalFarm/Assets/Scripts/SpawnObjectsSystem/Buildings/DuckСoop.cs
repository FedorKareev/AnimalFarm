using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;


public class DuckСoop : SpawnObjectsBase, IDestroyer
{
    private Market _market;

    [SerializeField]
    private List<Goose> _gooses = new List<Goose>();
    [SerializeField]
    private GardenbedScript[] _gardenBeds;
    [SerializeField]
    private GameObject _gooseCoopPanel;
    [SerializeField]
    private GameObject _goose;
    [SerializeField]
    private TextMeshPro _ammountOfGoosesText;

    private int _manure;
    private float _manureTimeSpawn = 60;
    private float _timer;

    [field: SerializeField]
    public ItemData itemData { get; set; }

    public int Manure
    {
        get
        {
            return _manure;
        }
    }

    private void Start()
    {
        _gardenBeds = FindObjectsOfType<GardenbedScript>();
        _market = FindObjectOfType<Market>();
    }
    private void Update()
    {
        if (_gooses.Count != 0)
        {
            Debug.Log(_manureTimeSpawn);
            _timer += Time.deltaTime;
            if (_timer >= _manureTimeSpawn)
            {
                ManurSpawner();
                _timer = 0f;
            }
        }
        _ammountOfGoosesText.text = $"{_gooses.Count.ToString()}/4";
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
    public override void SelectObject(int Index)
    {
        if (_gooses.Count < 4)
        {
            float gooseMultiplier = 1.15f;
            GameObject goose = Instantiate(_goose, transform.position + new Vector3(Random.Range(1, -1), transform.position.y, Random.Range(1, -1)), Quaternion.identity);
            _gooses.Add(goose.GetComponent<Goose>());
            _manureTimeSpawn /= gooseMultiplier;
        }
        else
        {
            _goose.GetComponent<Goose>().Animal.Amount++;
        }
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
                _gooses[i].CollectPlants();
            }
        }
    }
    public void DestroyBuilding()
    {
        itemData.Amount++;
        Destroy(gameObject);
        foreach (var gooses in _gooses)
        {
            Destroy(gooses.gameObject);
        }
    }
    public void ClearManure()
    {
        _manure = 0;
    }

    public void ManurSpawner()
    {
        _manure++;
    }
}
