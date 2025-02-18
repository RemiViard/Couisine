using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField] Stage1Basket basket;
    [SerializeField] GameObject stage2;

    void Start()
    {
        basket.onAdd += OnBasketUpdate;
    }

    void OnBasketUpdate() {
        // Condition to go to stage2
        if (basket.transform.childCount == 4) {
            GoToStage2();
        }
    }

    void GoToStage2() {
        basket.transform.parent = stage2.transform;
        gameObject.SetActive(false);
        stage2.SetActive(true);
    }
}
