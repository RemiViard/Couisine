using System.Linq;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    [SerializeField] GameObject items;
    [SerializeField] FallingSpawner spawner;
    [SerializeField] GameObject stage4;

    void OnEnable()
    {
        spawner.queue.Append(items);
        foreach (Transform child in items.transform) {
            spawner.queue.Enqueue(child.gameObject);
        }
        Debug.Log(spawner.queue.Count);
    }
    void NextStage()
    {
        stage4.SetActive(true);
        gameObject.SetActive(false);
    }
}
