using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSteering : MonoBehaviour
{
    public float AccelerationSpeed = 1f;
    public float SteeringSpeed = .01f;

    private Vector2 moveInput;
    private Vector2 smoothMoveInput;
    private Vector2 velocityMoveInput;


    //private PlayerInputs pI;
    private Rigidbody2D rB;

    private void Start()
    {
        //pI = GetComponent<PlayerInputs>();
        rB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        DrivingSpeed();
        Steering();
    }

    private void DrivingSpeed()
    {
        smoothMoveInput = Vector2.SmoothDamp(smoothMoveInput, moveInput, ref velocityMoveInput, .1f);
        rB.velocity = smoothMoveInput * AccelerationSpeed;
    }

    private void OnMove(InputValue value)
    {
        
        moveInput = value.Get<Vector2>();
    }
    private void Steering()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMoveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, SteeringSpeed * Time.deltaTime);

            rB.MoveRotation(rotation);
        }
    }
}
