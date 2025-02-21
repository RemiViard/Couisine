using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField] Stage1Basket basket;
    [SerializeField] GameObject stage2;
    
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
    }

    void OnBasketUpdate() {
        // Condition to go to stage2
        if (basket.transform.childCount == 4) {
            NextStage();
        }
    }

    void NextStage() {
        stage2.SetActive(true);
        gameObject.SetActive(false);
        state = EState.Steack;
    }
}
