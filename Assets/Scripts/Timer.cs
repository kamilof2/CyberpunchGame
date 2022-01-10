using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text timerText;
    public float seconds, minutes,time;
    public bool timerIsRunning;
    

    // Start is called before the first frame update
    void Start()
    {
        
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            time += Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time % 60);
            
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
