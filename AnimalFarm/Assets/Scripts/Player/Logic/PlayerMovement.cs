using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerRotationSpeed;
    [SerializeField]
    private GameInput playerInput;
    [SerializeField]
    private LayerMask layers;
    public static bool IsMoveble;

    private bool isWalking;

    private void Start()
    {
        IsMoveble = true;
    }
    void Update()
    {
        if (IsMoveble)
        {
            HandleMovement();
        }
        else
        {
            isWalking = false;
        }
    }

    void HandleMovement()
    {
        float moveDistanse = playerMoveSpeed * Time.deltaTime;
        float rotationDistace = playerRotationSpeed * Time.deltaTime;
        float playerRadius = .3f;
        float playerHeight = 2;
        if (!Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, playerInput.GetMoveMentVectorNormalized(), 1, layers))
        {
            Vector3 moveDirection = playerInput.GetMoveMentVectorNormalized();
            transform.position += moveDirection * moveDistanse;
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationDistace);
            isWalking = moveDirection != Vector3.zero;
        }
        else
        {
            isWalking = false;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
