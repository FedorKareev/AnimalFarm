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
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .7f;
        float playerHeight = 2f;
        float moveDistance = playerMoveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance, layers);

        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);
                if (canMove)
                {
                    moveDirection = moveDirectionZ;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;

        //Поворот
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * playerRotationSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
