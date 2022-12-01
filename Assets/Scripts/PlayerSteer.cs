using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSteer : MonoBehaviour
{
    public float AccelerationSpeed = 1f;
    public float SteeringSpeed = .01f;

    private Vector2 moveInput;

    private void Update()
    {
        if (moveInput != Vector2.zero)
        {
            Accelerating();
            Steering();
        }
    }

    private void Accelerating()
    {
        transform.Translate(0, AccelerationSpeed, 0);
    }
    private void Steering()
    {
        transform.Rotate(0, 0, -SteeringSpeed);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
