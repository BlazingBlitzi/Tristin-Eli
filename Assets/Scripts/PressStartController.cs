using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStartController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Debug.Log(this);
            gameObject.SetActive(false);
        }
    }
}
