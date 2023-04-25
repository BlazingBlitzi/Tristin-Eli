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
        if (collision.gameObject.tag == "Player")
        {
            GC = GameObject.FindGameObjectWithTag("GameController");
            GCS = GC.GetComponent<GCScript>();
            GCS.Damage(100);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
