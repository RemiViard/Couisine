using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Tuto tuto;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject intro;
    public void CloseIntro()
    {
        intro.SetActive(false);
        menu.SetActive(true);
    }
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
