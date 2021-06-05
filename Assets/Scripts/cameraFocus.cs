using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
/*

// Start is called before the first frame update
public Transform player;
public float cameraDistance = 150.0f;

    
    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

private void FixedUpdate()
{
    transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
}
*/


public Transform player;
public float cameraDistance = 150.0f;
public float xMin;
public float xMax;
public float yMin;
public float yMax;


private void FixedUpdate()
{
    if (player != null)
    {
        float x = Mathf.Clamp(player.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
}
