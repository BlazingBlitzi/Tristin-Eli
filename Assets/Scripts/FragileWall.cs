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
    private float WallHealth = 10f;
    private GameObject PlayerPos;
    private bool vacuum;
    PlayerScript pS;
    private BoxCollider2D col;
    private SpriteRenderer spr;

    /// <summary>
    /// This script will be attached to walls with hitboxes. When the bullet
    /// (and later, the player) hits the wall, it will be damaged. 
    /// </summary>

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            WallHealth -= 3f;
            print(WallHealth);
        }
        if (WallHealth <= 0f)
        {
            col = gameObject.GetComponent<BoxCollider2D>();
            spr = gameObject.GetComponent<SpriteRenderer>();
            col.enabled = false;
            spr.enabled = false;

            Suck();
            print("sucking");
            //Destroy(gameObject);
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
            PlayerPos = GameObject.Find("Player1");
            pS = PlayerPos.GetComponent<PlayerScript>();


            Vector3 difAngle = (PlayerPos.transform.position - transform.position);
            //pS.rb2d.AddForce(difAngle.normalized * -20f * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    /// <summary>
    /// This coroutine is a timer for how long the vacuum suck will last. After
    /// 3 seconds, it will delete the script and whatever its on. 
    /// </summary>
    IEnumerator SpaceVacuum()
    {
        yield return new WaitForSeconds(3f);
        vacuum = false;
        print("vacuum false");
        Destroy(this);
    }
}
