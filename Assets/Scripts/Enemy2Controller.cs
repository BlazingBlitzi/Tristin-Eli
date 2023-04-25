using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2Controller : MonoBehaviour
{
    private PlayerAwarenessController PAC;
    public Rigidbody2D rb2d;
    private Vector2 patrolDirection = new Vector2(1, 0);

    private Transform playerPos;
    public Transform BulletSpawn;

    public GameObject EnemyLaser;

    private float angle;
    private Vector3 direction;
    private float playerRange;

    public float cooldownTimer = 5f;
    private bool canShoot = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(DecisionChecker());
    }
    IEnumerator DecisionChecker()
    {
        yield return new WaitForSeconds(3f);
        Decision();
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(patrolDirection.x, patrolDirection.y);

        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            return;
        }
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerRange = Vector2.Distance(transform.position, playerPos.transform.position);

        direction = playerPos.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;

        if (playerRange <= 7 && canShoot == true)
        {
            StartCoroutine(ShootFunction());
        }
    }
    IEnumerator ShootFunction()
    {
        canShoot = false;
        Instantiate(EnemyLaser, BulletSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldownTimer);
        canShoot = true;
    }
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
            patrolDirection.x = 0;
            patrolDirection.y = 0;
            StartCoroutine(DecisionChecker());
        }
        
    }
}
