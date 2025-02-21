using System.Linq;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GameObject stage4;

    void OnEnable()
    {
        timer.SetTimer(5f);
        timer.timerEnd.AddListener(OnTimerEnd);
    }
    void OnTimerEnd()
    {
        timer.timerEnd.RemoveListener(OnTimerEnd);
        NextStage();
    }
    void NextStage()
    {
        gameObject.SetActive(false);
        stage4.SetActive(true);
    }
}
