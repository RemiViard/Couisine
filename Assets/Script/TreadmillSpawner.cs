using System.Collections.Generic;
using UnityEngine;

public class TreadmillSpawner : MonoBehaviour
{
    [SerializeReference] private List<GameObject> _ingredients;
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private Stage1Basket basket;

    public float _speed = 8f;

    private float _timer = 0f;

    private HashSet<GameObject> _currentlyOnTreadmill = new HashSet<GameObject>();

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        SpawnRandomIngredient();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _maxTime) {
            SpawnRandomIngredient();
            _timer = 0f;
        }
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
        foreach (var obj in _currentlyOnTreadmill) {
            Destroy(obj);
        }
    }
}
