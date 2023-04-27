using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrapScript : MonoBehaviour
{
    public float warningTime = 5f;
    public float laserTime = 2f;
    public float repeatTime = 5f;
    public GameObject warningCircle;
    public GameObject badCircle;

    private GameObject GC;
    private GCScript GCS;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Laser());
        GC = GameObject.FindGameObjectWithTag("GameController");
        GCS = GC.GetComponent<GCScript>();
    }

    private IEnumerator Laser()
    {
        yield return new WaitForSeconds(repeatTime);

        warningCircle.SetActive(true);

        yield return new WaitForSeconds(warningTime);

        warningCircle.SetActive(false);
        badCircle.SetActive(true);

        yield return new WaitForSeconds(laserTime);

        badCircle.SetActive(false);
        StartCoroutine(Laser());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            GCS.p1Damage(100);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player(Clone)")
        {
            GCS.p2Damage(100);
            Destroy(gameObject);
        }
    }

}