using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> Targets = new List<Transform>();
    private int currentNumber = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination = Targets[currentNumber].position;
        float distanse = Vector3.Distance(transform.position, Targets[currentNumber].position);
        if(distanse > 3)
        {
            currentNumber++;
        }
        if (distanse < 0) 
        {
            currentNumber = 0;
        }
    }
}
