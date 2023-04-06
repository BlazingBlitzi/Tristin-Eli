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

        Destroy(gameObject, 3.5f);
        //Destroys this gameObject after 3.5 seconds (optimization)
    }

    private void FixedUpdate()
    {
        transform.Translate(moveVector);
    }
}
