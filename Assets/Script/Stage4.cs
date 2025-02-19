using UnityEngine;

public class Stage4 : MonoBehaviour
{
    [SerializeField] Menu menu;
    void ReturnMenu()
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
