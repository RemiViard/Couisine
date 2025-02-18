using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField] GameObject stage3;

    void Start()
    {
        // TODO


    }
    void NextStage()
    {
        gameObject.SetActive(false);
        stage3.SetActive(true);
    }
}
