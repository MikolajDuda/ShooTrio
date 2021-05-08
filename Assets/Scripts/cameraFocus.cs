using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFocus : MonoBehaviour
{
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
}
