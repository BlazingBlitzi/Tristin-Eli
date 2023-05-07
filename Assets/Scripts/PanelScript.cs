/*****************************************************************************
// File Name :         PanelScript
// Author :            Elijah Vroman
// Creation Date :     4/12/2023
// Brief Description : This script is for doors. It will allow them to open 
// and close by making the gameObjects active and inactive. Further 
// development may be put into place to put multiple panel abilities on this 
// code to lower # of scripts. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    private bool doorOpen = false;
    private SpriteRenderer spr;
    public GameObject Door;

    /// <summary>
    /// If the bullet hits whatever this script is on, it will take the door
    /// gameObject on the script and disable it and vice versa. 
    /// </summary>
    public void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = Color.red;

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && doorOpen == false)
        {
            Door.SetActive(false);
            doorOpen= true;
            spr.color = Color.green;
        }
        else
        {
            Door.SetActive(true);
            doorOpen = false;
            spr.color = Color.red;
        }
    }
}
