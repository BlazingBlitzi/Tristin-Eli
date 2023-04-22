using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    private PlayerAwarenessController PAC;
    public Rigidbody2D rb2d;
    private Vector2 patrolDirection = new Vector2(1, 0);

    public GameObject EnemyBulletPrefab;
    public Transform EnemyFront;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PAC = GetComponent<PlayerAwarenessController>();
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

        if (PAC.AwareOfPlayer)
        {

        }
    }
    void Decision()
    {
        int decisionNum = Random.Range(1, 4);
        print("100 " + decisionNum);

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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
