using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    private bool doorClosed = false;
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
        if (collision.gameObject.tag == "Bullet" && doorClosed == false)
        {
            print("hit");
            Door.SetActive(true);
            doorClosed = true;
        }
        else if (collision.gameObject.tag == "Bullet" && doorClosed == true)
        {
            print("hit");
            Door.SetActive(false);
            doorClosed= false;
        }
    }
}
