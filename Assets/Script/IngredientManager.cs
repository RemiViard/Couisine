using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public List<Ingredient> ingredients;
    public List<Ingredient> cuttables;
    public List<Ingredient> cookables;
    public List<Ingredient> breadables;
    public List<Piece> condiment1;
    public List<Piece> condiment2;
    public List<Piece> meat;
    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
        switch (ingredient.type)
        {
            case Ingredient.EType.ECuttable:
                cuttables.Add(ingredient);
                break;
            case Ingredient.EType.ECookable:
                cookables.Add(ingredient);
                break;
            case Ingredient.EType.EBreadable:
                breadables.Add(ingredient);
                break;
        }
    }
    public void Clear()
    {
        ingredients.Clear();
        cuttables.Clear();
        cookables.Clear();
        breadables.Clear();
        condiment1.Clear();
        condiment2.Clear();
        meat.Clear();
    }
}
