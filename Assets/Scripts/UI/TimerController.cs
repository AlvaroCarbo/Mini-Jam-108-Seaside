using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime, time;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isFinished) {
            timerText.color = Color.yellow;
            return;
        }  
        if (GameManager.Instance.isPaused) return;
        time = Time.time - startTime;
        string timer = GameManager.Instance.formatFloatToTime(time);
        timerText.text = timer;
        GameManager.Instance.Time = timer;
        GameManager.Instance.TimeFloat = time;
    }
}
