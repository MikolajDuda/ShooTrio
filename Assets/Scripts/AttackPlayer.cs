using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{

    private float force = 20;
    private CameraFocus cameraFocus;
    private Transform _target;

    private void Start()
    {
        cameraFocus = GameObject.FindWithTag("MainCamera").GetComponent<CameraFocus>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Kill Player
            other.gameObject.GetComponent<PlayerStatistics>().alive = false;

            // Treat Player like a spirit 
            other.rigidbody.bodyType = RigidbodyType2D.Kinematic;
            
            // Kick them out
            other.rigidbody.velocity =  
              new Vector2(force * GetComponent<Rigidbody2D>().velocity.x + other.rigidbody.velocity.x, force * 13);
            
            // Wait a few seconds for camera focus on the murderer
            StartCoroutine(cameraToGoat(0.5f));
          
            // After 3s show Menu
            StartCoroutine(EndAttempt(3));
        }

        if (!other.gameObject.CompareTag("Goat")) return;
        // Destroy goat
        Destroy(other.gameObject);
            
        GetComponent<BossBehaviour>().OnAttacked();

        if (GetComponent<BossBehaviour>().hp <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerStatistics>().finished = true;
        }
    }

    IEnumerator cameraToGoat(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        var transform1 = transform;
        cameraFocus.player = transform1;
        GetComponent<EnemyAI>().target = transform1;
    }
    
    // Delay in function execution
    IEnumerator EndAttempt(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<EnemyAI>().target = other.transform;
            GetComponent<EnemyAI>().speed += GetComponent<EnemyAI>().triggerSpeed;
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
            GetComponent<EnemyAI>().speed -= GetComponent<EnemyAI>().triggerSpeed;
        }
    }
}
