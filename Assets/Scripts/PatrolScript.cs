using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform posA;
    public Transform posB;
    private Vector2 nextPosition;
    public GameObject enemy;

    private void Start()
    {
        nextPosition = posA.position;
    }

    private void Update()
    {
        if (enemy.transform.position == posA.position)
        {
            nextPosition = posB.position;
        }
        else if (enemy.transform.position == posB.position)
        {
            nextPosition = posA.position;
        }

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, nextPosition, moveSpeed * Time.deltaTime);
    }
}
