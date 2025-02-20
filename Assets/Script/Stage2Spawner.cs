using System.Collections.Generic;
using UnityEngine;

public class Stage2Spawner : MonoBehaviour
{
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] float spawnDelay;
    [SerializeField] Transform spawnPos;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        InvokeRepeating(nameof(SpawnRandomIngredient), 0, spawnDelay);
    }
    void SpawnRandomIngredient()
    {
        GameObject prefab = ingredientManager.cuttables[Random.Range(0, ingredientManager.cuttables.Count - 1)].gameObject;
        GameObject ingredient = Instantiate(prefab, gameObject.transform);
        ingredient.transform.position = spawnPos.position;
        ingredient.GetComponent<Rigidbody>().useGravity = true;
        Destroy(ingredient.transform.GetChild(0).gameObject);
    }
}
