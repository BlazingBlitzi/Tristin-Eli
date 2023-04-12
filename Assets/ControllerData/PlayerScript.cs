using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private float airPuff;

    public Vector2 lookDirection;
    public Vector2 lastLookDirection;

    Rigidbody2D rb2d;
    public GameObject BulletPrefab;
    public Transform playerFront;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;
    //Vector2 rotation;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        Instantiate(BulletPrefab, playerFront.position, Quaternion.identity);
    }
    public void RotateInDirectionOfInput(InputAction.CallbackContext ctx)
    {
        lookDirection = ctx.ReadValue<Vector2>();
        if (lookDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    public void UseAirPuff(InputAction.CallbackContext ctx)
    {
        rb2d.AddForce(lookDirection * airPuff, ForceMode2D.Impulse);
    }

    public void Update()
    {
          
    }

}
