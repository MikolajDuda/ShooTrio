using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respBloodyGoat : MonoBehaviour
{

    private UnityEngine.Object bloodyGoat;
    [SerializeField] private GameObject goat;
    public bool isGoatKilled = false;
    private GameObject ref2Goat;
    private Vector2 position;

    // Update is called once per frame

    private void Start()
    {
        bloodyGoat = goat;
        //ref2Goat = RespBloodyGoat();
    }
    

    void Update()
    {
        if (isGoatKilled)
        {
            StartCoroutine(Wait());
            isGoatKilled = false;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    GameObject RespBloodyGoat()
    {
        GameObject bloodyGoatGameObject = (GameObject)Instantiate(Resources.Load("Bloody Goat"), transform.position, Quaternion.identity);
        bloodyGoatGameObject.GetComponentInChildren<EnemyAI>().speed = 400;
        bloodyGoatGameObject.GetComponentInChildren<EnemyAI>().triggerSpeed = 400;
        bloodyGoatGameObject.GetComponentInChildren<EnemyAI>().edgeToPatrol = 10;
        foreach (Transform t in bloodyGoatGameObject.transform)
        {
            t.gameObject.tag = "Goat";
        }
        
        return bloodyGoatGameObject;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        ref2Goat = RespBloodyGoat();
    }
}
