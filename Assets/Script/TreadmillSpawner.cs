using System.Collections.Generic;
using UnityEngine;

public class TreadmillSpawner : MonoBehaviour
{
    [SerializeReference] private List<GameObject> _ingredients;
    [SerializeField] GameObject ingredientColliderPrefab;
    [SerializeField] private float _spawnDelay = 0.2f;
    [SerializeField] private Stage1Basket basket;

    public float _speed = 16f;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        InvokeRepeating(nameof(SpawnRandomIngredient), 0, _spawnDelay);
    }

    private void SpawnRandomIngredient() {
        var prefab = _ingredients[Random.Range(0, _ingredients.Count)];
        var instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = gameObject.transform;
        
        var moveScript = instance.AddComponent<MoveIngredientOnTreadmill>();
        moveScript._speed = _speed;
        GameObject collider = Instantiate(ingredientColliderPrefab, instance.transform);
        collider.transform.localPosition = Vector3.zero;
        var clickableScript = instance.AddComponent<Clickable>();
        clickableScript.OnClick += () => {
            Destroy(moveScript);
            Destroy(clickableScript);
            basket.AddItem(instance);
        };
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
