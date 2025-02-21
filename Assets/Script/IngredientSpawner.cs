using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] float spawnDelay;
    [SerializeField] Transform spawnPos;
    [SerializeField] Ingredient.EType type;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        InvokeRepeating(nameof(SpawnRandomIngredient), 0, spawnDelay);
    }
    void SpawnRandomIngredient()
    {
        GameObject prefab = null;
        switch (type)
        {
            case Ingredient.EType.ECuttable:
                prefab = ingredientManager.cuttables[Random.Range(0, ingredientManager.cuttables.Count - 1)].gameObject;
                break;
            case Ingredient.EType.ECookable:
                prefab = ingredientManager.cookables[Random.Range(0, ingredientManager.cookables.Count - 1)].gameObject;
                break;
            case Ingredient.EType.EBreadable:
                prefab = ingredientManager.breadables[Random.Range(0, ingredientManager.breadables.Count - 1)].gameObject;
                break;
        }
        GameObject ingredient = Instantiate(prefab, gameObject.transform);
        ingredient.transform.position = spawnPos.position;
        ingredient.GetComponent<Rigidbody>().useGravity = true;
        Destroy(ingredient.transform.GetChild(0).gameObject);
    }
}
