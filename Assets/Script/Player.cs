using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction select;
    void Start()
    {
        select = InputSystem.actions.FindAction("Select");
        select.performed += Select;
    }

    private void Select(InputAction.CallbackContext obj)
    {
        Debug.Log(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
