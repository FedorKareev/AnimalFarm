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
    private int timer;
    [SerializeField]
    private State state;

    private Transform startPosition;
    private Transform _target;
    private Transform _market;
    private NavMeshAgent _agent;
    private float _destination;
    private Action _onTargetPos;

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
        _agent = GetComponent<NavMeshAgent>();
        timer = GardenbedScript.TIMEFOR_COLLECT;
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
        _agent.SetDestination(_target.position);
        state = State.Moving;
    }

    private void OnStartPosition()
    {
        _agent.ResetPath();
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
        _agent.enabled = true;
        AnimalMove(_target, () => StartCoroutine(Timer(() => AnimalMove(_market, () => StartCoroutine(Timer(() => AnimalMove(startPosition, ()=> OnStartPosition())))))));
    }
}
