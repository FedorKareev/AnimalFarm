using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector3 GetMoveMentVectorNormalized()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");
        var moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = new Vector3(moveHorizontal, 0, moveVertical);

        inputDirection = inputDirection.normalized;

        return inputDirection;
    }
}
