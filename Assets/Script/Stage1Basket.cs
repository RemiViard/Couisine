using System.Collections.Generic;
using UnityEngine;

public class Stage1Basket : MonoBehaviour
{
    public List<GameObject> basket = new List<GameObject>();

    public float offset = 2.0f;

    public void AddItem(GameObject obj) {
        obj.transform.position = transform.position + Vector3.right * offset * basket.Count;
        basket.Add(obj);
    }
}
