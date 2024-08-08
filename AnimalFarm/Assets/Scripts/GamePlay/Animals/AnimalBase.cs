using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AnimalBase : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform market;

    private NavMeshAgent agent;
    private float timer = 0f;
    public bool isMove = false;

    private Vector3 startPosition;

    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isMove)
        {
            AnimalMove();
        }
    }

    private void OnEnable()
    {
        Duck—oop.onMove += IsMoveSwitcher;
    }
    private void OnDisable()
    {
        Duck—oop.onMove -= AnimalMove;
    }

    private void AnimalMove()
    {
        agent.SetDestination(target.position);
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            timer += Time.deltaTime;
            if (timer >= GardenbedScript.TIMEFOR_COLLECT) 
            {
                timer = 0f;
                target = market.transform;
                agent.SetDestination(market.position);
                isMove = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GardenbedScript gardenBed = collider.gameObject.GetComponent<GardenbedScript>();
        if (gardenBed != null && gardenBed.IsSpawned)
        {
            gardenBed.CollectPlants();
        }
    }
    private void IsMoveSwitcher()
    {
        isMove = true;
    }
}
