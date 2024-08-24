using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AnimalWalk : MonoBehaviour, IUnit
{
    [SerializeField]
    private NavMeshAgent agent;

    public void MoveTo(Vector3 position, System.Action arrivedAtPosition)
    {
        agent.destination = position;
        arrivedAtPosition?.Invoke();
    }
    public void WaitForSeconds(float delayTime, Action onTimerComplete)
    {
       
    }
    
}
