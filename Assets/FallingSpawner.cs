using System.Collections.Generic;
using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float xRandomOffset = 6f;

    public Queue<GameObject> queue = new Queue<GameObject>();

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0.0f, spawnDelay);
    }

    void Spawn() {
        if (queue.Count <= 0) return;
        var obj = queue.Dequeue();
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
        obj.transform.position += Vector3.right * Random.Range(-xRandomOffset, xRandomOffset);
        obj.AddComponent<Rigidbody>();
    }

    void OnDisable()
    {
        
    }
}
