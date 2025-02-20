using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float time;
    public UnityEvent timerEnd;
    [SerializeField] GameObject timerUi; 
    [SerializeField] Text min;
    [SerializeField] Text sec;
    bool activated;
    public void SetTimer(int value)
    {
        time = value;
        activated = true;
        timerUi.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(activated)
        {
            time -= Time.deltaTime;
            SetUI();
            if(time <= 0)
            {
                timerEnd.Invoke();
                time = 0;
                activated = false;
                timerUi.SetActive(false);
            }
        }
    }
    void SetUI()
    {
        int timeInt = (int)time;
        int minInt = timeInt / 60;
        int secInt = timeInt - minInt * 60;
        SetText(min, minInt);
        SetText(sec, secInt);
    }
    void SetText(Text text, int value)
    {
        if (value < 10)
            text.text = "0" + value.ToString();
        else
            text.text = value.ToString();
    }
}
