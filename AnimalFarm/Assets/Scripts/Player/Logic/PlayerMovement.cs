using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerRotationSpeed;
    [SerializeField]
    private GameInput playerInput;
    public bool IsMoveble;

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

        Vector3 moveDirection = playerInput.GetMoveMentVectorNormalized();
        transform.position += moveDirection * moveDistanse;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationDistace);
        isWalking = moveDirection != Vector3.zero;
    }
    private void OnTriggerEnter(Collider collider)
    {
        GardenbedScript gardenBed = collider.gameObject.GetComponent<GardenbedScript>();
        if (gardenBed != null)
        {
            Debug.Log("Привет");
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
