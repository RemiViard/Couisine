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

        }
    }
}
