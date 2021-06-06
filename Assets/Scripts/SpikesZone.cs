using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesZone : MonoBehaviour
{

    [SerializeField] public int seconds = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStatistics>().alive = false;
            StartCoroutine(EndAttempt());
        }
    }
    
    IEnumerator EndAttempt()
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }
}
