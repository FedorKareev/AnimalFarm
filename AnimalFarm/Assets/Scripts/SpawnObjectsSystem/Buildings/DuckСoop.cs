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
            _timer += Time.deltaTime;
            if (_timer >= _manureTimeSpawn)
            {
                ManurSpawner();
                _timer = 0f;
            }
        }
        _ammountOfGoosesText.text = $"{_gooses.Count.ToString()}/4";

        for (int i = 0; i < _gooses.Count; i++) 
        {
            if (_gooses[i].State == State.OnStartPosition)
            {
                MoveAnimals();
            }
        }
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
            List<GardenbedScript> matureGardenBeds = new List<GardenbedScript>();
            for (int i = 0; i < _gooses.Count; i++)
            {
                for (int j = 0; j < _gardenBeds.Length; j++)
                {
                    if (!_gardenBeds[j].GetIsMaturing())
                    {
                        matureGardenBeds.Add(_gardenBeds[j]);
                        if (matureGardenBeds.Count != 0)
                        {
                            GardenbedScript tempGardenBed = matureGardenBeds[Random.Range(0, matureGardenBeds.Count)];
                            _gooses[i].Target = tempGardenBed.transform;
                            _gooses[i].Market = _market.transform;
                            _gooses[i].StartPosition = gameObject.transform;
                            _gooses[i].GardenBed = tempGardenBed;
                            _gooses[i].CollectPlants();
                        }
                    }
                }
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
