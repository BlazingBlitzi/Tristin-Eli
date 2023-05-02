using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserBehavior : MonoBehaviour
{
    private GameObject PlayerPos;
    private Rigidbody2D rb;
    private GameObject GC;
    private GCScript GCS;
    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController");
        GCS = GC.GetComponent<GCScript>();


        rb = GetComponent<Rigidbody2D>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player");


        Vector3 difAngle = (PlayerPos.transform.position - transform.position);
        //Finds difference from players transform and balls transform after ball is spawned

        rb.AddForce(difAngle.normalized * 18f, ForceMode2D.Impulse);
        //Add force takes destination/endpoint and a magnitude.

        Destroy(gameObject, 3f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            GCS.p1Damage(10);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player(Clone)")
        {
            GCS.p2Damage(10);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
