using System.Linq;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GameObject stage4;
    [SerializeField] Stage3VictoryBox victoryBox;

    void OnEnable()
    {
        timer.SetTimer(30f);
        timer.timerEnd.AddListener(OnTimerEnd);
    }
    void OnTimerEnd()
    {
        timer.timerEnd.RemoveListener(OnTimerEnd);
        victoryBox.CheckMeat();
        NextStage();
    }
    void NextStage()
    {
        gameObject.SetActive(false);
        stage4.SetActive(true);
    }
}
