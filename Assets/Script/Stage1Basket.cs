using System.Collections.Generic;
using UnityEngine;

public class Stage1Basket : MonoBehaviour
{
    public float offset = 2.0f;

    public void AddItem(GameObject obj) {
        obj.transform.position = transform.position + Vector3.right * offset * gameObject.transform.childCount;
        obj.transform.parent = gameObject.transform;
    }
}
