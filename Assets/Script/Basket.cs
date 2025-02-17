using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private List<GameObject> basket = new List<GameObject>();

    public float offset = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddItem(GameObject obj) {
        obj.transform.position = transform.position + Vector3.right * offset * basket.Count;
        basket.Add(obj);
    }
}
