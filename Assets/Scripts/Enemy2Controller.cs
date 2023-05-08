/*****************************************************************************
// File Name :         Enemy2Controller
// Author :            Elijah Vroman
// Creation Date :     4/13/23
// Brief Description : This script governs the main enemy. He has a random 
number picker to decide what direction he will move, while firing at the 
players.
*****************************************************************************/
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2Controller : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    private Vector2 patrolDirection = new Vector2(1, 0);

    private Transform playerPos;
    public Transform BulletSpawn;

    public GameObject EnemyLaser;

    private float angle;
    private Vector3 direction;
    private float playerRange;

    private float cooldownTimer = 5f;
    private bool canShoot = true;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(DecisionChecker());
    }


    /// <summary>
    /// This courutine will call the decision function after 3 seconds as long 
    /// as the enemy exists.
    /// </summary>
    IEnumerator DecisionChecker()
    {
        yield return new WaitForSeconds(3f);
        Decision();
    }


    /// <summary>
    /// In Update, the enemy moves according to how fast Decision() chose. It 
    /// will then find the player and determine how far away it is and at what 
    /// angle so that it faces the player and can check if it can fire.
    /// </summary>
    void FixedUpdate()
    {
        
        Rb2d.velocity = new Vector2(patrolDirection.x, patrolDirection.y);

        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            return;
        }
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerRange = Vector2.Distance(transform.position, playerPos.transform.position);

        direction = playerPos.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Rb2d.rotation = angle;

        if (playerRange <= 7 && canShoot == true)
        {
            StartCoroutine(ShootFunction());
        }
    }
    /// <summary>
    /// When called, the Shootfunction will instantiate an enemybullet. A 
    /// separate script on the bullet itself will find and target the 
    /// players.
    /// </summary>
    IEnumerator ShootFunction()
    {
        canShoot = false;
        Instantiate(EnemyLaser, BulletSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldownTimer);
        canShoot = true;
    }
    /// <summary>
    /// First, this function calls a random number. It then checks what number
    /// was picked to decide how fast and in what direction the enemy will go
    /// with its X and Y values.
    /// </summary>
    void Decision()
    {
        int decisionNum = Random.Range(1, 4);

        if (decisionNum == 1)
        {
            //FastPatrol
            int decisionNumY = Random.Range(-1, 2);
            int decisionNumX = Random.Range(1, -2);

            patrolDirection.x = decisionNumX *2f;
            patrolDirection.y = decisionNumY *2f;
            StartCoroutine(DecisionChecker());
        }
        if (decisionNum == 2)
        {
            //SlowPatrol
            int decisionNumY = Random.Range(-1, 2);
            int decisionNumX = Random.Range(1, -2);

            patrolDirection.x = decisionNumX;
            patrolDirection.y = decisionNumY;
            StartCoroutine(DecisionChecker());
        }
        if (decisionNum == 3)
        {
            //StopPatrol
            patrolDirection.x = 0;
            patrolDirection.y = 0;
            StartCoroutine(DecisionChecker());
        }
        
    }
}
