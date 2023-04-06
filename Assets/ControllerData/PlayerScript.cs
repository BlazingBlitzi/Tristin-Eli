using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;
    InputAction look;
    InputAction shoot;

    Vector2 movement;
    Vector3 lookAround;

    public Rigidbody2D Laser;
    public Transform playerFront;

    // Start is called before the first frame update
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActionMap");

        move = inputMap.FindAction("Move");
        look = inputMap.FindAction("Look");
        shoot = inputMap.FindAction("Shoot");

        move.performed += contx => movement = contx.ReadValue<Vector2>();
        move.canceled += contx => movement = Vector2.zero;

        look.performed += contx => lookAround = contx.ReadValue<Vector2>();
        look.canceled += contx => lookAround = Vector2.zero;

        shoot.performed += contx => ShootGun();
    }
    public void ShootGun()
    {
        Instantiate(Laser, playerFront.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.Self);

        Vector2 lookAroundVelocity = new Vector2(-lookAround.y, lookAround.x) * 5f * Time.deltaTime;
        transform.Rotate(lookAroundVelocity, Space.Self);

        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
