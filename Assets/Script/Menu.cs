using UnityEngine;
using UnityEngine.SceneManagement;

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
        bgMusic.Stop();
        menuMusic.Play();
    }
    public void Play()
    {
        tuto.ShowTuto(0);
        menu.SetActive(false);
        bgMusic.Play();
        menuMusic.Stop();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
