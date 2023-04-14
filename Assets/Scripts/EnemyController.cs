/*****************************************************************************
// File Name :         EnemyController
// Author :            Tristin Hendrickson
// Creation Date :     4/13/2023
// Brief Description : Our main enemy script, this is where our enemy is
not only Aware, but can also rotate and go towards the player. Our Awareness,
script partners with this, so we can add functions such as a patrol route.
In this version, the enemy will just wander around.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// Establishing the floats and grabbing components, this is also where
    /// we grab out Awareness Script to work together with our enemies
    /// behaviour.
    /// </summary>
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb2d;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private float changeDirectionCooldown;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();


    }

    /// <summary>
    /// This uses Rotation to do a wander mechanic, this will allow the enemy
    /// to do more than just run into walls.
    /// </summary>
    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if (changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    /// <summary>
    /// As the name implies, this is where we do our player targeting with use
    /// of the Player Awareness Controller
    /// </summary>
    private void HandlePlayerTargeting()
    {
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
    }

    /// <summary>
    /// And finally we use this to have the enemy rotate to the player. So if 
    /// the player ends up in sight, they can chase after the Player
    /// </summary>
    private void RotateTowardsTarget()
    {
        

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, 
            targetRotation, rotationSpeed * Time.deltaTime);

        rb2d.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        rb2d.velocity = transform.up * speed;
    }
}
