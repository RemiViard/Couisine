using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    [SerializeField] List<Sprite> tutoSprites;
    [SerializeField] List<GameObject> stages;
    [SerializeField] Image tutoUi;
    int currentTuto;

    public void ShowTuto(int stageId)
    {
        tutoUi.gameObject.SetActive(true);
        tutoUi.sprite = tutoSprites[stageId];
        currentTuto = stageId;
    }
    public void CloseButton()
    {
        tutoUi.gameObject.SetActive(true);
        stages[currentTuto].SetActive(true);
    }
}
