/*****************************************************************************
// File Name :         EnemyLaserBehavior
// Author :            Elijah Vroman
// Creation Date :     4/15/23
// Brief Description : This script is brief, but important. Here the bullet 
itself will find the player and move towards it at a given speed.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserBehavior : MonoBehaviour
{
    private GameObject PlayerPos;
    private Rigidbody2D rb;
    private GameObject GC;
    private GCScript GCS;


    /// <summary>
    /// The bullet does several things in start. It finds the GC script, as 
    /// well as the nearest player. Using its own as well as the players'
    /// positions, it finds a vector to move towards the player.
    /// </summary>
    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController");
        GCS = GC.GetComponent<GCScript>();


        rb = GetComponent<Rigidbody2D>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player");


        Vector3 difAngle = (PlayerPos.transform.position - transform.position);
        //Finds difference from players transform and balls transform after ball is spawned

        rb.AddForce(difAngle.normalized * 18f, ForceMode2D.Impulse);
        //Add force takes destination/endpoint and a magnitude.

        Destroy(gameObject, 3f);
    }


    /// <summary>
    /// Here the bullet is checking what it hit. In order that the game doesnt
    /// have a bunch of bullets floating around after they are "fired," they
    /// are automatically destroyed when hitting anything.
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            GCS.p1Damage(10);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player(Clone)")
        {
            GCS.p2Damage(10);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
