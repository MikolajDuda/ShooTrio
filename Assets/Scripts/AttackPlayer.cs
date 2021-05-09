using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] private float force = 10;

    [SerializeField] private CameraFocus _cameraFocus;
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.velocity =
                new Vector2(force * GetComponent<Rigidbody2D>().velocity.x + other.rigidbody.velocity.x, force * 3);

            _cameraFocus.player = transform;
            GetComponent<EnemyAI>().target = transform;
         //   GetComponent<Movement>().hitted = true;
        }
    }
}
