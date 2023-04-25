/*****************************************************************************
// File Name :         PlayerScript
// Author :            Elijah Vroman
// Creation Date :     4/5/23
// Brief Description : This script governs everything about player1, mainly
// controller inputs and player actions.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public Transform Child;


    [SerializeField]
    private float airPuff;
    private float ammoCount = 8;
    private float ROF = 0;

    public Vector2 lookDirection;
    public Vector2 lastLookDirection;

    public Rigidbody2D rb2d;
    public GameObject BulletPrefab;
    public Transform playerFront;


    /// <summary>
    /// On script awake, it will get its own rigidbody
    /// </summary>
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ammoCount = 8f;
        
    }
    private void FixedUpdate()
    {
        
    }
    /// <summary>
    /// This is the shoot function. If the player has ammo and the time since 
    /// they last shot (basically ROF) checks out, a bullet will be instantiated
    /// Also removes 1 ammo. If there is no ammo, the reloadingGun() is activated
    /// </summary>
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ammoCount > 0f && Time.time > ROF + 0.125f)
        {
            GameObject newBullet = Instantiate(BulletPrefab, playerFront.position, Quaternion.identity);
            newBullet.GetComponent<LaserBlastController>().Shoot(lastLookDirection);
            ROF = Time.time;
            --ammoCount;
        }
        else if (ammoCount <= 0f)
        {
            ReloadingGun();
        }
    }
    /// <summary>
    /// Similar to how I did the FragileWall script, this function just starts 
    /// the coroutine.
    /// </summary>
    public void ReloadingGun()
    {
        StartCoroutine(Reload());
        print("RELOADING");
    }
    /// <summary>
    /// Afrer 3 seconds, the ammocount is restored to 8.
    /// </summary>
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);
        ammoCount = 8f;
    }
    /// <summary>
    /// This is the movement section. First, it gets a vector2 from the
    /// controller, i.e., where the stick is in X and Y terms. Then, if 
    /// there is a stick input (not 0), that value is saved as 
    /// lastLookDirection. With a MathFTan and a transform.rotation, 
    /// the player will rotate in accordance with the stick.
    /// </summary>
    public void RotateInDirectionOfInput(InputAction.CallbackContext ctx)
    {
        lookDirection = ctx.ReadValue<Vector2>();
        if (lookDirection != Vector2.zero)
        {
            lastLookDirection= lookDirection;
            float angle = Mathf.Atan2(lastLookDirection.y, lastLookDirection.x) * Mathf.Rad2Deg;
            Child.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    /// <summary>
    /// This is how the player moves, or transforms through the level. The 
    /// airburst is to simulate compressed air being released in a vacuum to 
    /// propel an object at an equal amount to the backwards force from the air
    /// </summary>

    public void UseAirPuff(InputAction.CallbackContext ctx)
    {
        rb2d.AddForce(lastLookDirection * airPuff, ForceMode2D.Impulse);
    }
}
