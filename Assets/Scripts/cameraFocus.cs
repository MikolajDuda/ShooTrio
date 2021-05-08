using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 150.0f;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    
    private void FixedUpdate()
    {
        float x = Mathf.Clamp(player.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
