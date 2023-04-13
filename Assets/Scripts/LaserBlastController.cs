using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlastController : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletRB2D;
    PlayerScript PS;

    private void Start()
    {
        PS = GameObject.Find("TestPlayer").GetComponent<PlayerScript>();
        bulletRB2D = GetComponent<Rigidbody2D>();
        bulletRB2D.AddForce(PS.lastLookDirection * 30f, ForceMode2D.Impulse);

        Destroy(gameObject, 3.5f);
        //Destroys this gameObject after 3.5 seconds (optimization)

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
