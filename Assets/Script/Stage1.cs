using UnityEngine;
using UnityEngine.UI;

public class Stage1 : MonoBehaviour
{
    [SerializeField] Stage1Basket basket;
    [SerializeField] GameObject stage2;
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
            NextStage();
        }
        else
        {
            state++;
            ChangeUI();
        }
            
    }

    void NextStage() {
        stage2.SetActive(true);
        gameObject.SetActive(false);
        state = EState.Steack;
        UIPanel.SetActive(false);
    }
    void ChangeUI()
    {
        UIText.text = "Select your " + state.ToString();
    }
}
