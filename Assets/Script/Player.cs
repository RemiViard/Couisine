using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction cut;
    InputAction leftClick;
    InputAction rightClick;
    Vector3 enterPos;
    float lastMouseX;
    [SerializeField] Knife knife;
    void Start()
    {
        cut = InputSystem.actions.FindAction("Space");
        cut.performed += Cut;
        leftClick = InputSystem.actions.FindAction("leftClick");
        rightClick = InputSystem.actions.FindAction("rightClick");
        lastMouseX = Input.mousePosition.x;
    }

    private void Cut(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Sliceable"))
            {
                Debug.Log("Slice");
                GameObject slice = Cutter.Cut(hit.collider.gameObject, hit.point, Vector3.up);
                slice.tag = "Sliceable";
                hit.collider.gameObject.name = hit.collider.gameObject.name + " Slice";
                slice.name = hit.collider.gameObject.name;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastMouseX != Input.mousePosition.x)
        {
            float newX = knife.transform.position.x + (Input.mousePosition.x - lastMouseX) * Time.deltaTime * knife.sensitivity;
            newX = Math.Clamp(newX, -1, 1);
            knife.transform.position = new Vector3(newX, knife.transform.position.y, knife.transform.position.z);
            lastMouseX = Input.mousePosition.x;
        }
        float turnInput = 0;
        if (rightClick.IsPressed())
        {
            turnInput += 1;
        }
        if (leftClick.IsPressed())
        {
            turnInput += -1;
        }
        if (turnInput != 0)
        {
            float testedY = knife.transform.eulerAngles.y + turnInput * knife.rotationSensitivity;
            if ( testedY <= 30 || testedY >= 330)
                knife.transform.Rotate(new Vector3(0, turnInput * knife.rotationSensitivity, 0));
        }
    }
}
