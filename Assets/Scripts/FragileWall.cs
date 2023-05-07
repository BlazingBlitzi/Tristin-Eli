/*****************************************************************************
// File Name :         Fragile Wall
// Author :            Elijah Vroman
// Creation Date :     4/13/23
// Brief Description : This script deals with the fragile wall concept and the
// vacuum of space. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileWall : MonoBehaviour
{
    public float WallHealth = 10f;
    private GameObject PlayerPos;
    private bool vacuum;
    PlayerScript pS;
    private GameObject GC;
    private GCScript GCS;
    private Collider2D col;
    private SpriteRenderer spr;

    /// <summary>
    /// This script will be attached to walls with hitboxes. When the bullet
    /// (and later, the player) hits the wall, it will be damaged. 
    /// </summary>
    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController");
        GCS = GC.GetComponent<GCScript>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            WallHealth -= 3f;
            print(WallHealth);
        }
        if (WallHealth <= 0f)
        {
            col = gameObject.GetComponent<Collider2D>();
            spr = gameObject.GetComponent<SpriteRenderer>();
            col.enabled = false;
            spr.enabled = false;

            Suck();

        }
        if (collision.gameObject.name == "Player(Clone)" && collision.relativeVelocity.magnitude >= 1)
        {
            GCS.p2Damage (10f);
            WallHealth -= (2f * collision.relativeVelocity.magnitude);
        }
        if (collision.gameObject.name == "Player1" && collision.relativeVelocity.magnitude >= 1)
        {
            GCS.p1Damage(10f);
            WallHealth -= (2f * collision.relativeVelocity.magnitude);
        }

    }
    /// <summary>
    /// This f(x) is to start the space vacuum coroutine. Not much else. 
    /// </summary>
    public void Suck()
    {
        StartCoroutine(SpaceVacuum());
        vacuum = true;
    }
    /// <summary>
    /// Here, we will be finding the player script and the player's position. 
    /// difAngle just gets us a vector for addForce. 
    /// </summary>
    public void Update()
    {
        if (vacuum == true)
        {
            PlayerPos = GameObject.FindGameObjectWithTag("Player");
            pS = PlayerPos.GetComponent<PlayerScript>();


            Vector3 difAngle = (PlayerPos.transform.position - transform.position);
            pS.rb2d.AddForce(difAngle.normalized * -8f * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    /// <summary>
    /// This coroutine is a timer for how long the vacuum suck will last. After
    /// 3 seconds, it will delete the script and whatever its on. 
    /// </summary>
    IEnumerator SpaceVacuum()
    {
        yield return new WaitForSeconds(5f);
        vacuum = false;
        Destroy(this);
    }
}
