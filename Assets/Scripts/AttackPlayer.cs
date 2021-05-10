using System;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] private float force = 10;

   [SerializeField] private CameraFocus cameraFocus;

    private Transform _target;
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.velocity =
                new Vector2(force * GetComponent<Rigidbody2D>().velocity.x + other.rigidbody.velocity.x, force * 3);

            var transform1 = transform;
            cameraFocus.player = transform1;
            GetComponent<EnemyAI>().target = transform1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<EnemyAI>().target = other.transform;
            GetComponent<EnemyAI>().speed *= 2;
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        _target = GetComponent<EnemyAI>().target;
        if (other.gameObject.CompareTag("Player"))
        {
            _target = other.transform;
        }
    }
*/
    
    private void OnTriggerExit2D(Collider2D other)
    {
        _target = GetComponent<EnemyAI>().target;
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<EnemyAI>().target = null;
            GetComponent<EnemyAI>().speed /= 2;
        }
    }
}
