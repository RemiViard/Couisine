using System.Linq;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    [SerializeField] GameObject items;
    [SerializeField] FallingSpawner spawner;

    void OnEnable()
    {
        spawner.queue.Append(items);
        foreach (Transform child in items.transform) {
            spawner.queue.Enqueue(child.gameObject);
        }
        Debug.Log(spawner.queue.Count);
    }
}
