using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Stage3VictoryBox : MonoBehaviour
{
    [SerializeField] GameObject steam;
    [SerializeField] Transform meatDrawer;
    List<Ingredient> meat = new List<Ingredient>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Ingredient ingredient))
        {
            if(ingredient.type == Ingredient.EType.ECookable)
            {
                meat.Add(ingredient);
                Instantiate(steam, ingredient.transform);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ingredient ingredient))
        {
            if (ingredient.type == Ingredient.EType.ECookable)
            {
                meat.Remove(ingredient);
                Destroy(ingredient.transform.GetChild(0).gameObject);
            }
        }
    }
    public void CheckMeat()
    {
        foreach (var ingredient in meat)
        {
            ingredient.transform.parent = meatDrawer;
            Destroy(ingredient.transform.GetChild(0).gameObject);
            ingredient.transform.localPosition = Vector3.zero;
        }
    }
}
