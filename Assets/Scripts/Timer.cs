using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerGUI;
    [SerializeField] private PlayerStatistics _playerStatistics;
    [SerializeField] private GameObject killedPanel;
    [SerializeField] private GameObject winPanel;
    private GameObject timer;
    private bool _stopped;
    private static float time;
    private static float _startTime;
    private string hours;
    private string minutes;
    private string seconds;

    // Update is called once per frame
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
            time = Time.time - _startTime;
       //     hours = ((int) (t / 60) / 60).ToString();
            minutes = ((int) time / 60).ToString();
            seconds = (time % 60).ToString("f2");
            SetTimer();
        }
    }

    public void StartClock()
    {
        _startTime = Time.time;
    }
    
    public void Finished()
    {
        _stopped = true;
        TimerGUI.color = Color.green;
        TimerGUI.fontSize = (float) (TimerGUI.fontSize + 0.01);
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            return;
        }
        
        StartCoroutine(ShowMenu());
    }

    public void Killed()
    {
        _stopped = true;
        TimerGUI.color = Color.red;
        TimerGUI.fontSize = (float) (TimerGUI.fontSize + 0.01);
        if (killedPanel != null)
        {
            killedPanel.SetActive(true);
        }
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
