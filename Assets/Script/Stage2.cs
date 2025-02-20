using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GameObject stage3;
    private void OnEnable()
    {
        timer.SetTimer(5);
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
        stage3.SetActive(true);
    }
}
