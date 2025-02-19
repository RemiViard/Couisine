using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject stage1;
    public void Play()
    {
        stage1.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
