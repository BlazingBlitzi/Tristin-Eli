/*****************************************************************************
// File Name :         CameraController
// Author :            Tristin Hendrickson
// Creation Date :     4/13/2023
// Brief Description : A simple camera controlling script so the camera can 
follow the player without being attached directly and doesnt get caught
in the rotation.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
