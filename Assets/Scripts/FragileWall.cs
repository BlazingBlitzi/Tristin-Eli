using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileWall : MonoBehaviour
{
    private float WallHealth = 10f;
    private GameObject PlayerPos;
    private bool vacuum;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            WallHealth -= 3f;
        }
        if (WallHealth <= 0f)
        {
            Suck();

            Destroy(gameObject);

        }
    }
    public void Suck()
    {
        StartCoroutine(SpaceVacuum());
        vacuum = true;
       
        if (vacuum == true)
        {
            PlayerPos = GameObject.Find("Player1");
            Vector3 difAngle = (PlayerPos.transform.position - transform.position);

        }
    }
    IEnumerator SpaceVacuum()
    {
        yield return new WaitForSeconds(3f);
        vacuum = false;
    }
}
