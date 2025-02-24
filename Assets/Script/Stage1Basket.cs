using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Basket : MonoBehaviour
{
    public float offset = 2.0f;

    public event Action onAdd;
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] TreadmillSpawner treadmillSpawner;

    public void AddItem(GameObject obj)
    {
        Ingredient ingredient = obj.GetComponent<Ingredient>();
        if (IngredientIsValid(ingredient))
        {
            obj.GetComponent<MoveIngredientOnTreadmill>().enabled = false;
            Destroy(obj.transform.GetChild(0).gameObject);
            obj.transform.position = transform.position + Vector3.right * offset * gameObject.transform.childCount;
            obj.transform.parent = gameObject.transform;
            ingredientManager.AddIngredient(ingredient);
            obj.GetComponent<Rigidbody>().isKinematic = false;
            treadmillSpawner.RemoveSelectedIngredientFromList(obj.GetComponent<Ingredient>());
            onAdd?.Invoke();
        }
    }
    bool IngredientIsValid(Ingredient ingredient)
    {
        if ((treadmillSpawner.stage1.state == Stage1.EState.Top
            || treadmillSpawner.stage1.state == Stage1.EState.Bot)
            && ingredient.type == Ingredient.EType.EBreadable
            && ingredientManager.breadables.Count < 2)
        {
            foreach (var bread in ingredientManager.breadables)
            {
                if (bread.id == ingredient.id)
                    return false;
            }
            return true;
        } 
        else if ((treadmillSpawner.stage1.state == Stage1.EState.Condiment1
            || treadmillSpawner.stage1.state == Stage1.EState.Condiment2)
            && ingredient.type == Ingredient.EType.ECuttable
            && ingredientManager.breadables.Count < 2)
        {
            foreach (var condiment in ingredientManager.cuttables)
            {
                if (condiment.id == ingredient.id)
                    return false;
            }
            return true;
        } 
        else if (treadmillSpawner.stage1.state == Stage1.EState.Steak && ingredient.type == Ingredient.EType.ECookable)
            return true;

        return false;
    }
}
