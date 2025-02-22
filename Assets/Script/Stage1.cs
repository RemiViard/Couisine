using UnityEngine;
using UnityEngine.UI;

public class Stage1 : MonoBehaviour
{
    [SerializeField] Stage1Basket basket;
    [SerializeField] Tuto tuto;
    [SerializeField] GameObject UIPanel;
    [SerializeField] Text UIText;
    public enum EState
    {
        Steack,
        Condiment1,
        Condiment2,
        Top,
        Bot,
    }
    public EState state;
    void Start()
    {
        basket.onAdd += OnBasketUpdate;
        state = EState.Steack;
        ChangeUI();
        UIPanel.SetActive(true);
    }

    void OnBasketUpdate() {
        if (state == EState.Bot)
        {
            Debug.Log("wtf");
            NextStage();
        }
        else
        {
            state++;
            ChangeUI();
        }
            
    }

    void NextStage() {
        gameObject.SetActive(false);
        state = EState.Steack;
        UIPanel.SetActive(false);
        tuto.ShowTuto(1);
    }
    void ChangeUI()
    {
        UIText.text = "Select your " + state.ToString();
    }
}
