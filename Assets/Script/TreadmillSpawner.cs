using System.Collections.Generic;
using UnityEngine;

public class TreadmillSpawner : MonoBehaviour
{
    [SerializeReference] private List<GameObject> ingredient;
    public List<GameObject> steack = new List<GameObject>();
    public List<GameObject> condiment = new List<GameObject>();
    public List<GameObject> bread = new List<GameObject>();
    public Stage1 stage1;
    [SerializeField] GameObject ingredientColliderPrefab;
    [SerializeField] private float _spawnDelay = 0.2f;
    [SerializeField] private Stage1Basket basket;

    public float _speed = 16f;

    void OnEnable()
    {
        int count = 0;
        foreach (var ingredient in ingredient)
        {
            ingredient.GetComponent<Ingredient>().id = count;
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
            count++;
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
        else if (stage1.state == Stage1.EState.Steak)
            prefab = steack[Random.Range(0, steack.Count)];

        var instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = gameObject.transform;
        var moveScript = instance.AddComponent<MoveIngredientOnTreadmill>();
        moveScript._speed = _speed;
        GameObject collider = Instantiate(ingredientColliderPrefab, instance.transform);
        collider.transform.localPosition = Vector3.zero;
    }
    public void RemoveSelectedIngredientFromList(Ingredient ingredient)
    {
        switch (ingredient.type)
        {
            case Ingredient.EType.ECuttable:
                condiment.RemoveAll(s => s.GetComponent<Ingredient>().id == ingredient.id);
                break;
            case Ingredient.EType.ECookable:
                steack.RemoveAll(s => s.GetComponent<Ingredient>().id == ingredient.id);
                break;
            case Ingredient.EType.EBreadable:
                bread.RemoveAll(s => s.GetComponent<Ingredient>().id == ingredient.id);
                break;
        }
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
