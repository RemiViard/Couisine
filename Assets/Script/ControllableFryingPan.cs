using UnityEngine;

public class ControllableFryingPan : MonoBehaviour
{
    [SerializeField] float xRange = 6.0f;

    void Start()
    {
        
    }

       void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        float normalizedX = mousePosition.x / Screen.width * 2 - 1;
        transform.position = new Vector3(xRange * normalizedX, transform.position.y, transform.position.z);
    }
}
