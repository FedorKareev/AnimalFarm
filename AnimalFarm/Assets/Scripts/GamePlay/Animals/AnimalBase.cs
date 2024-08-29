using System;
using System.Collections;
using Unity.AI.Navigation.Samples;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Moving,
    OnStartPosition,
    Collecting
}

[RequireComponent(typeof(NavMeshAgent))]
public class AnimalBase : MonoBehaviour
{
    protected State state;
    protected int timer;
    protected Transform startPosition;
    protected Transform _target;
    protected Transform _market;
    protected NavMeshAgent _agent;
    protected float _destination;
    protected Action _onTargetPos;
    [SerializeField]
    protected ItemData _animal;

    public State State
    {
        get 
        { 
            return state; 
        }
    }


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
    public Transform Market
    {
        get
        {
            return _market;
        }
        set
        {
            _market = value;
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
        state = State.OnStartPosition;
    }

    protected void HandleMove()
    {
        float destination = Vector3.Distance(transform.position, _target.position);
        if (destination <= 5)
        {
            Debug.Log("Я пришёл");
            _onTargetPos?.Invoke();
        }
    }

    protected void AnimalMove(Transform target, Action onTargetPos)
    {
        _onTargetPos = onTargetPos;
        _target = target;
        _agent.SetDestination(_target.position);
        state = State.Moving;
    }

    protected void OnStartPosition()
    {
        Debug.Log("Я на стартовой позиции");
        state = State.OnStartPosition;
    }

    protected IEnumerator Timer(Action OnTimerEnd)
    {
        state = State.Idle;
        yield return new WaitForSeconds(5);
        OnTimerEnd?.Invoke();
    }
}
