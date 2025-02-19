using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Basket : MonoBehaviour
{
    public float offset = 2.0f;

    public event Action onAdd;
    [SerializeField] IngredientManager ingredientManager;

    public void AddItem(GameObject obj) {
        obj.transform.position = transform.position + Vector3.right * offset * gameObject.transform.childCount;
        obj.transform.parent = gameObject.transform;
        ingredientManager.AddIngredient(obj.GetComponent<Ingredient>());
        onAdd?.Invoke();
    }
}
