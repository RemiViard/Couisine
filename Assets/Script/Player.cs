using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction select;
    Vector3 enterPos;
    void Start()
    {
        select = InputSystem.actions.FindAction("Select");
        //select.performed += Select;
    }

    private void Select(InputAction.CallbackContext obj)
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
        if (select.IsPressed())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Sliceable"))
                {
                    if (enterPos == null)
                        enterPos = hit.point;
                }
            }

        }
    }
}
