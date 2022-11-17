using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSteering : MonoBehaviour
{
    public float AccelerationSpeed = 1f;
    public float SteeringSpeed = .01f;

    private Vector2 moveInput;
    
    //private PlayerInputs pI;
    private Rigidbody2D rB;

    private void Start()
    {
        //pI = GetComponent<PlayerInputs>();
        rB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rB.MovePosition(rB.position + moveInput * AccelerationSpeed * Time.fixedDeltaTime);

    }
    private void OnMove(InputValue value)
    {
        transform.Translate(0, AccelerationSpeed, 0);
    }
    private void OnSteer(InputValue value)
    {
        transform.Rotate(0, 0, SteeringSpeed);
    }
}
