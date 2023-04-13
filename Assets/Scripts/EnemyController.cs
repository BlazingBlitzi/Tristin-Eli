using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb2d;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;


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
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
        
    }

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
