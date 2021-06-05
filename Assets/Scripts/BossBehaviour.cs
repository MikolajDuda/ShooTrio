using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] public float hp = 100f;
    [SerializeField] private float healthDrop = 10f;

    public void OnAttacked()
    {
        hp -= healthDrop;
        
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
