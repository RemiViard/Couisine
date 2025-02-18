using System.Collections.Generic;
using UnityEngine;

public class TreadmillSpawner : MonoBehaviour
{
    [SerializeReference] private List<GameObject> _ingredients;
    [SerializeField] private float _spawnDelay = 0.2f;
    [SerializeField] private Stage1Basket basket;

    public float _speed = 16f;

    private HashSet<GameObject> _currentlyOnTreadmill = new HashSet<GameObject>();

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        InvokeRepeating(nameof(SpawnRandomIngredient), 0, _spawnDelay);
    }

    private void SpawnRandomIngredient() {
        var prefab = _ingredients[Random.Range(0, _ingredients.Count-1)];
        var instance = Instantiate(prefab, transform.position, Quaternion.identity);
        _currentlyOnTreadmill.Add(instance);
        
        var moveScript = instance.AddComponent<MoveIngredientOnTreadmill>();
        moveScript._speed = _speed;

        var clickableScript = instance.AddComponent<Clickable>();
        clickableScript.OnClick += () => {
            _currentlyOnTreadmill.Remove(instance);
            Destroy(moveScript);
            Destroy(clickableScript);
            basket.AddItem(instance);
        };
    }

    void OnDisable()
    {
        CancelInvoke();
        foreach (var obj in _currentlyOnTreadmill) {
            Destroy(obj);
        }
    }
}
