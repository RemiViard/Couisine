using System.Linq;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Tuto tuto;
    [SerializeField] Stage3VictoryBox victoryBox;

    void OnEnable()
    {
        timer.SetTimer(30f);
        timer.timerEnd.AddListener(OnTimerEnd);
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
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
        tuto.ShowTuto(3);
    }
}
