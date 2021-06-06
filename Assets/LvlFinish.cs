using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlFinish : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStatistics>().finished = true;
            StartCoroutine(ShowMenu());
        }
    }

    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
