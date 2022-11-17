using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Controls myControls;
    private Vector2 moveInput;
    public float ValueX = 1f;

    private void Awake()
    {
        myControls = new Controls();
    }
    private void OnEnable()
    {
        myControls.Player.Steering.performed += StartSteering;
        myControls.Player.Steering.canceled += StartSteering;

        myControls.Player.Disable();

        //myControls.Disable(); //All controls are disabled
    }
    private void OnDisable()
    {
        myControls.Player.Steering.performed -= StartSteering;
        myControls.Player.Steering.canceled -= StartSteering;

        myControls.Player.Enable();
    }
    private void StartSteering(InputAction.CallbackContext ctx)
    {
        ValueX = Mathf.RoundToInt(ctx.ReadValue<float>());
    }
    private void StopSteering(InputAction.CallbackContext ctx)
    {
        ValueX = 0;
    }
    private void OnSteering(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
