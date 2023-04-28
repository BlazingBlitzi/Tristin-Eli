using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressStartController : MonoBehaviour
{

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction start;

    Vector2 startButton;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        start = inputMap.FindAction("Start");

        start.performed += contx => startButton = contx.ReadValue<Vector2>();
        start.canceled += contx => startButton = Vector2.zero;



    }

    private void Update()
    {

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
