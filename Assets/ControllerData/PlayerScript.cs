using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private float airPuff;
    private float ammoCount;

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
        ammoCount = 8f;
        
    }
    private void FixedUpdate()
    {
        
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ammoCount > 0f)
        {
            Instantiate(BulletPrefab, playerFront.position, Quaternion.identity);
            --ammoCount;
        }
        else ReloadingGun();
    }
    public void ReloadingGun()
    {
        StartCoroutine(Reload());
        print("RELOADING");
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);
        ammoCount = 8f;
    }



    public void RotateInDirectionOfInput(InputAction.CallbackContext ctx)
    {
        lookDirection = ctx.ReadValue<Vector2>();
        if (lookDirection != Vector2.zero)
        {
            lastLookDirection= lookDirection;
            float angle = Mathf.Atan2(lastLookDirection.y, lastLookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void UseAirPuff(InputAction.CallbackContext ctx)
    {
        rb2d.AddForce(lastLookDirection * airPuff, ForceMode2D.Impulse);
    }

    public void Update()
    {
          
    }

}
