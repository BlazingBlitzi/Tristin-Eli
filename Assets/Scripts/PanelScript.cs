using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    private bool doorOpen = false;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && doorOpen == false)
        {
            print("hit");
            Door.SetActive(false);
            doorOpen= true;
        }
        if (collision.gameObject.tag == "Bullet" && doorOpen == true)
        {
            Door.SetActive(true);
            doorOpen= false;
        }
    }
}
