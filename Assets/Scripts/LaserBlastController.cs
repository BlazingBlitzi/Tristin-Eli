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
    public float speed;
    Rigidbody2D bulletRB2D;
    PlayerScript PS;


    /// <summary>
    /// On start, the bullet finds the Player and uses the direction the player
    /// is facing to figure out what vector it will be sent * a force. 
    /// </summary>
    private void Start()
    {
        PS = GameObject.Find("Player1").GetComponent<PlayerScript>();
        bulletRB2D = GetComponent<Rigidbody2D>();

        bulletRB2D.AddForce(PS.lastLookDirection * 30f, ForceMode2D.Impulse);

        Destroy(gameObject, 3.5f);
        //Destroys this gameObject after 3.5 seconds (optimization)

    }
    /// <summary>
    /// If a bullet hits another bullet, they will destroy each other so they
    /// dont bounce around.
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this);
        }
    }
}
