using UnityEngine;

public class MoveIngredientOnTreadmill : MonoBehaviour
{
    public float _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * Time.deltaTime * _speed;
    }
}
