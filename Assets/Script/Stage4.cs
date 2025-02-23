using UnityEngine;

public class Stage4 : MonoBehaviour
{
    [SerializeField] Menu menu;
    [SerializeField] Bin bin;
    public void ReturnMenu()
    {
        bin.ClearBin();
        menu.Restart();
        gameObject.SetActive(false);
    }
}
