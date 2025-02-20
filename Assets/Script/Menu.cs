using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject stage1;
    [SerializeField] GameObject menu;
    public void Play()
    {
        stage1.gameObject.SetActive(true);
        menu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
