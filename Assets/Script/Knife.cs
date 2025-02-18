using UnityEngine;
using System.Collections;
public class Knife : MonoBehaviour
{
    public float sensitivity;
    public float rotationSensitivity;
    public float cutPos;
    bool isBusy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cut()
    {
        if (!isBusy)
        {
            isBusy = true;
            StartCoroutine(Tchak());
        }
            

    }
    IEnumerator Tchak()
    {

        yield return null;
    }
}