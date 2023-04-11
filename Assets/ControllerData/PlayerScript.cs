using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    /*InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;
    InputAction rotate;*/

    [SerializeField]
    private float airPuff;

    private Vector2 lookDirection;

    Rigidbody2D rb2d;
    /*private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    [SerializeField]
    private float speed;*/

    [SerializeField]
    private float rotationSpeed;
    //Vector2 rotation;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        /*inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActionMap");
        move = inputMap.FindAction("Move");
        rotate = inputMap.FindAction("Look");

        move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        move.canceled += ctx => movement = Vector2.zero;

        rotate.performed += ctx => rotation = ctx.ReadValue<Vector2>();
        rotate.canceled += ctx => rotation = Vector2.zero;*/
    }

    private void FixedUpdate()
    {
        //SetPlayerVelocity();
        //RotateInDirectionOfInput();
        /*Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        //Don't use Translate, use RigidBody's Velocity
        transform.Translate(movementVelocity, Space.Self);

        Vector2 rotationVelocity = new Vector2(rotation.x, rotation.y);
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, rotationVelocity);
        Quaternion rotateTowards = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f * Time.deltaTime);
        rb2d.MoveRotation(rotateTowards);*/
    }

    /*public void SetPlayerVelocity(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);

        rb2d.velocity = smoothedMovementInput * speed;
    }*/

    public void RotateInDirectionOfInput(InputAction.CallbackContext ctx)
    {
        lookDirection = ctx.ReadValue<Vector2>();
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void UseAirPuff(InputAction.CallbackContext ctx)
    {
        rb2d.AddForce(-lookDirection * airPuff, ForceMode2D.Impulse);
    }

    public void StopMoving(InputAction.CallbackContext ctx)
    {
        rb2d.velocity = Vector2.zero;
    }

    /*private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }*/
    /*private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }*/
}
