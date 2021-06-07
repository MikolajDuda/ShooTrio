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
            //other.gameObject.GetComponent<PlayerStatistics>().finished = true;
          //  StartCoroutine(Loadlvl2());
          SceneManager.LoadScene("Level2");
        }
    }

    IEnumerator Loadlvl2()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level2");
    }
}
