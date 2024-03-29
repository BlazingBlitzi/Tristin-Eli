/*****************************************************************************
// File Name :         LaserBlastController
// Author :            Elijah Vroman
// Creation Date :     4/5/23
// Brief Description : This script governs everything about the bullet once
// it is instantiated. 
*****************************************************************************/
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlastController : MonoBehaviour
{
    public float speed = 30f;
    /// <summary>
    /// If a bullet hits another bullet, they will destroy each other so they
    /// dont bounce around.
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || (collision.gameObject.tag == "Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// This finds where the player is looking to make the bullet fly in that
    /// direction.
    /// </summary>
    public void Shoot(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);

        Destroy(gameObject, 3.5f);
        //Destroys this gameObject after 3.5 seconds (optimization)
    }
}
