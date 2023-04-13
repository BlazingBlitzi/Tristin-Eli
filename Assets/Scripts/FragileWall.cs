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
    public void Suck()
    {
        StartCoroutine(SpaceVacuum());
        vacuum = true;
    }
    public void Update()
    {
        if (vacuum == true)
        {
            PlayerPos = GameObject.Find("Player1");
            pS = PlayerPos.GetComponent<PlayerScript>();


            Vector3 difAngle = (PlayerPos.transform.position - transform.position);
            pS.rb2d.AddForce(difAngle.normalized * -20f * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    IEnumerator SpaceVacuum()
    {
        yield return new WaitForSeconds(3f);
        vacuum = false;
        print("vacuum false");
        Destroy(this);
    }
}
