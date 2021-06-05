using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] public BossBehaviour bb;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetHealth(bb.hp);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(bb.hp);
    }
}
