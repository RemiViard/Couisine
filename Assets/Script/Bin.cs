using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] Stage1Basket basket;
    [SerializeField] IngredientManager ingredientManager;
    public void ClearBin()
    {
        for (int i = 0; i < basket.transform.childCount; i++)
        {
            Destroy(basket.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        ingredientManager.Clear();
    }

}
