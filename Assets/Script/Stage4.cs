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
    private void OnEnable()
    {
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
