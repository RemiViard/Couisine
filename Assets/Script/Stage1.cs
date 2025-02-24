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
        Steak,
        Condiment1,
        Condiment2,
        Top,
        Bot,
    }
    public EState state;
    void Start()
    {
        basket.onAdd += OnBasketUpdate;
        state = EState.Steak;
        ChangeUI();
        UIPanel.SetActive(true);
    }
    private void OnEnable()
    {
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
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
        gameObject.SetActive(false);
        state = EState.Steak;
        UIPanel.SetActive(false);
        tuto.ShowTuto(1);
    }
    void ChangeUI()
    {
        UIText.text = "Select your " + state.ToString();
    }
}
