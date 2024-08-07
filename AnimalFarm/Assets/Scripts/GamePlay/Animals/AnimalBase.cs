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
    private float delayTime = 5f;
    private bool isMove = false;

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
    private void Update()
    {
        if (isMove)
        {
            AnimalMove();
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        Duck—oop.onMove += IsMoveSwitcher;
    }
    private void OnDisable()
    {
        Duck—oop.onMove -= IsMoveSwitcher;
    }

    private void AnimalMove()
    {
        agent.SetDestination(target.position);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                target = market.transform;
            }
        }   
    }
    private void IsMoveSwitcher()
    {
        isMove = true;
    }
}
