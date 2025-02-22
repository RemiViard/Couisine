using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] float spawnDelay;
    [SerializeField] Transform spawnPos;
    [SerializeField] Ingredient.EType type;
    [SerializeField] float force;

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
                prefab = ingredientManager.cuttables[Random.Range(0, ingredientManager.cuttables.Count )].gameObject;
                break;
            case Ingredient.EType.ECookable:
                prefab = ingredientManager.cookables[Random.Range(0, ingredientManager.cookables.Count )].gameObject;
                break;
            case Ingredient.EType.EBreadable:
                prefab = ingredientManager.breadables[Random.Range(0, ingredientManager.breadables.Count )].gameObject;
                break;
        }
        GameObject ingredient = Instantiate(prefab, gameObject.transform);
        ingredient.transform.position = spawnPos.position;
        Rigidbody rigidbody = ingredient.GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.AddRelativeForce(Vector3.down * force, ForceMode.Force);
        if (ingredient.transform.childCount > 0)
            Destroy(ingredient.transform.GetChild(0).gameObject);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
