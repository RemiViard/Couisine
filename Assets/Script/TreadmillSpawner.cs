using System.Collections.Generic;
using UnityEngine;

public class TreadmillSpawner : MonoBehaviour
{
    [SerializeReference] private List<GameObject> ingredient;
    private List<GameObject> steack = new List<GameObject>();
    private List<GameObject> condiment = new List<GameObject>();
    private List<GameObject> bread = new List<GameObject>();
    [SerializeField] Stage1 stage1;

    [SerializeField] GameObject ingredientColliderPrefab;
    [SerializeField] private float _spawnDelay = 0.2f;
    [SerializeField] private Stage1Basket basket;

    public float _speed = 16f;

    void OnEnable()
    {
        foreach (var ingredient in ingredient)
        {
            switch (ingredient.GetComponent<Ingredient>().type)
            {
                case Ingredient.EType.ECuttable:
                    condiment.Add(ingredient);
                    break;
                case Ingredient.EType.ECookable:
                    steack.Add(ingredient);
                    break;
                case Ingredient.EType.EBreadable:
                    bread.Add(ingredient);
                    break;
            }
        }
        Random.InitState(System.DateTime.Now.Millisecond);
        InvokeRepeating(nameof(SpawnRandomIngredient), 0, _spawnDelay);
    }

    private void SpawnRandomIngredient() {
        GameObject prefab = null;
        if (stage1.state == Stage1.EState.Condiment1 || stage1.state == Stage1.EState.Condiment2)
            prefab = condiment[Random.Range(0, condiment.Count)];
        else if (stage1.state == Stage1.EState.Top || stage1.state == Stage1.EState.Bot)
            prefab = bread[Random.Range(0, bread.Count)];
        else if (stage1.state == Stage1.EState.Steack)
            prefab = steack[Random.Range(0, steack.Count)];

        var instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = gameObject.transform;
        
        var moveScript = instance.AddComponent<MoveIngredientOnTreadmill>();
        moveScript._speed = _speed;
        GameObject collider = Instantiate(ingredientColliderPrefab, instance.transform);
        collider.transform.localPosition = Vector3.zero;
    }

    void OnDisable()
    {
        CancelInvoke();
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
