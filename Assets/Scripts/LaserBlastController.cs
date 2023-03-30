using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlastController : MonoBehaviour
{
    public float speed;

    Vector3 moveVector;

    private void Start()
    {
        moveVector = Vector3.up * speed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        transform.Translate(moveVector);
    }
}
