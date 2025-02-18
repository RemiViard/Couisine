using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField] GameObject stage3;

    void Start()
    {
        // TODO
        gameObject.SetActive(false);
        stage3.SetActive(true);
    }
}
