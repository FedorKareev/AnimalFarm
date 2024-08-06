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

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        AnimalMove();
    }

    private void AnimalMove()
    {
        StartCoroutine(TakeCrops());
    }
    private IEnumerator TakeCrops()
    {
        float distanceToWayPoint = Vector3.Distance(target.position, transform.position);
        if (distanceToWayPoint <= 1)
        {
            yield return new WaitForSeconds(1);
            agent.SetDestination(market.position);
        }
    }
}
