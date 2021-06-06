using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float _timer = 0.0f;
    [SerializeField] private TextMeshProUGUI TimerGUI;
    [SerializeField] private PlayerStatistics _playerStatistics;
    private bool _stopped;
    private float _startTime;
    private string hours;
    private string minutes;
    private string seconds;

    // Update is called once per frame

    private void Start()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        if (!_playerStatistics.alive)
        {
            Killed();
        }
        
        if (_playerStatistics.finished)
        {
            Finished();
        }
        
        if (!_stopped)
        {
            float t = Time.time - _startTime;
       //     hours = ((int) (t / 60) / 60).ToString();
            minutes = ((int) t / 60).ToString();
            seconds = (t % 60).ToString("f2");
            SetTimer();
        }
    }

    public void Finished()
    {
        _stopped = true;
        TimerGUI.color = Color.green;
        TimerGUI.fontSize = (float) (TimerGUI.fontSize + 0.01);
        StartCoroutine(ShowMenu());
    }

    public void Killed()
    {
        _stopped = true;
        TimerGUI.color = Color.red;
        TimerGUI.fontSize = (float) (TimerGUI.fontSize + 0.01);
    }
    
    private void SetTimer()
    {
      //  TimerGUI.text = hours + ":" + minutes + ":" + seconds;
        TimerGUI.text =  minutes + ":" + seconds;
    }
    
    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
