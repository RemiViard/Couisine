using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Tuto tuto;
    [SerializeField] GameObject menu;
    public void Play()
    {
        tuto.ShowTuto(0);
        menu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
