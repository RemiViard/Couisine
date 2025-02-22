using UnityEngine;

public class FryingPan : MonoBehaviour
{
    Vector3 lastMousePos;
    [SerializeField] Transform children;
    [SerializeField] float rotationSensitivity;
    [SerializeField] float rotationClamp;
    private void Start()
    {
        lastMousePos = Input.mousePosition;
    }
    private void Update()
    {
        if (lastMousePos != Input.mousePosition)
        {
            Vector2 input = Input.mousePosition - lastMousePos;
            input *= Time.deltaTime * rotationSensitivity;
            float testedZ = (transform.eulerAngles.z + input.x);
            if(testedZ <= rotationClamp || testedZ >= 360 - rotationClamp)
            {
                transform.Rotate(transform.forward, input.x, Space.World);
            }
            float testedX = (children.eulerAngles.x + input.y);
            if(testedX <= rotationClamp || testedX >= 360 - rotationClamp)
            {
                children.Rotate(children.right, input.y, Space.World);
            }
            lastMousePos = Input.mousePosition;
            if (!HasValidValue(transform.eulerAngles.z, children.eulerAngles.x))
            {
                children.transform.rotation = Quaternion.identity;
                transform.rotation = Quaternion.identity;
            }
                
        }
    }
    private bool HasValidValue(float value, float value2)
    {
        if ((value <= rotationClamp+10 || value >= 360 - (rotationClamp+10))
            && (value2 <= rotationClamp+10 || value2 >= 360 - (rotationClamp+10)))
            return true;
        return false;
                
    }
}
