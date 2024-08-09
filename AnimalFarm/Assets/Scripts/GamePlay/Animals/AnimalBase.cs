using System;
using System.Collections;
using Unity.AI.Navigation.Samples;
using UnityEngine;
using UnityEngine.AI;

enum State
{
    Idle,
    Moving,
    OnStartPosition
}

[RequireComponent(typeof(NavMeshAgent))]
public class AnimalBase : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform market;
    [SerializeField]
    private int timer;

    private Transform startPosition;
    private NavMeshAgent agent;
    private RandomWalk agentRandomWalk;
    private float _destination;
    private Action _onTargetPos;
    [SerializeField]
    private State state;
    private bool isMove = false;

    public Transform StartPosition
    {
        get
        {
            return startPosition;
        }
        set
        {
            startPosition = value;
        }
    }

    public Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.Moving:
                HandleMove();
                break;
        }

    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = GardenbedScript.TIMEFOR_COLLECT;
        agentRandomWalk = GetComponent<RandomWalk>();
    }

    private void HandleMove()
    {
        float destination = Vector3.Distance(transform.position, _target.position);
        if (destination <= 5)
        {
            Debug.Log("Я пришёл");
            _onTargetPos?.Invoke();
        }
    }

    private void AnimalMove(Transform target, Action onTargetPos)
    {
        _onTargetPos = onTargetPos;
        _target = target;
        agent.SetDestination(_target.position);
        state = State.Moving;
    }

    private void OnStartPosition()
    {
        agent.ResetPath();
        state = State.OnStartPosition;
    }

    private IEnumerator Timer(Action OnTimerEnd)
    {
        state = State.Idle;
        yield return new WaitForSeconds(timer);
        OnTimerEnd?.Invoke();
    }

    private void OnTriggerEnter(Collider collider)
    {
        GardenbedScript gardenBed = collider.gameObject.GetComponent<GardenbedScript>();
        if (gardenBed != null && gardenBed.IsSpawned)
        {
            gardenBed.CollectPlants();
        }
    }
    public void IsMoveSwitcher()
    {
        agentRandomWalk.enabled = false;
        agent.enabled = true;
        AnimalMove(_target, () => StartCoroutine(Timer(() => AnimalMove(market, () => StartCoroutine(Timer(() => AnimalMove(startPosition, ()=> OnStartPosition())))))));
    }
}
