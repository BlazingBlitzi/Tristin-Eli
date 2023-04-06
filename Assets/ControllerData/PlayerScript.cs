using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;
    InputAction rotate;

    Vector2 movement;
    Vector2 rotation;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActionMap");
        move = inputMap.FindAction("Move");
        rotate = inputMap.FindAction("Rotate");

        move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        move.canceled += ctx => movement = Vector2.zero;

        rotate.performed += ctx => rotation = ctx.ReadValue<Vector2>();
        rotate.canceled += ctx => rotation = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.Self);

        Vector2 rotationVelocity = new Vector2(rotation.x, rotation.y);
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, rotationVelocity);
        Quaternion rotateTowards = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f * Time.deltaTime);
        transform.Rotate(rotateTowards.eulerAngles);
    }

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
