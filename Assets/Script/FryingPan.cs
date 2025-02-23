using System;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    [SerializeField] Transform children;
    [SerializeField] float sensitivityX = 0.18f;
    [SerializeField] float sensitivityY = 0.11f;
    [SerializeField] float rotationClamp;
    private void Start()
    {

    }
    private void Update()
    {
        var x = (1 - 2 * Input.mousePosition.x / Screen.width) * sensitivityX;
        var y = (1 - 2 * Input.mousePosition.y / Screen.height) * sensitivityY;
        children.transform.rotation = Quaternion.Euler(
            360 * (y / 2 + 0.5f),
            360 * (x*y + 0.5f),
            360 * (x / 2 + 0.5f)
        );
    }
    private bool HasValidValue(float value, float value2)
    {
        if ((value <= rotationClamp+10 || value >= 360 - (rotationClamp+10))
            && (value2 <= rotationClamp+10 || value2 >= 360 - (rotationClamp+10)))
            return true;
        return false;
                
    }
}
