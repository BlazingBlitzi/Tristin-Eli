/*****************************************************************************
// File Name :         PlayerAwarenessController
// Author :            Tristin Hendrickson
// Creation Date :     4/13/2023
// Brief Description : This script is made for the enemies to track the player.
This is so our enemies can run after the player if and when they reach their
range of vision.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    /// <summary>
    /// Here we are establishing the Player Awareness, we do this by gather
    /// the data of the Player's location by finding the object of type. While
    /// also doing the direction, we need the enemy to chase after all.
    /// </summary>
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float playerAwarenessDistance;
    public Transform player;

    private void Awake()
    {
        //player = FindObjectOfType<PlayerScript>().transform;
    }

    
    /// <summary>
    /// Here is a bit more function to the player awareness, this is where our
    /// Distance is established and can be set with a public variable.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
