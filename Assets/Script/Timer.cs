using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public UnityEvent timerEnd;
    [SerializeField] GameObject timerUi; 
    [SerializeField] Text min;
    [SerializeField] Text sec;
    public bool activated;
    public void SetTimer(float value)
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
                time = 0f;
                activated = false;
                timerUi.SetActive(false);
                timerEnd.Invoke();
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
