using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Tuto tuto;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject intro;

    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource menuMusic;

    public void CloseIntro()
    {
        intro.SetActive(false);
        menu.SetActive(true);
    }
    public void Play()
    {
        tuto.ShowTuto(0);
        menu.SetActive(false);
        bgMusic.Play();
        menuMusic.Stop();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
