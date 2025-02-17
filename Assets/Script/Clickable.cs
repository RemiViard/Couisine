using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clickable : MonoBehaviour
{
    private InputAction select;
    private Action OnClick;

    public void SetOnClick(Action OnClick)
    {
        this.OnClick = OnClick;
    }

    void Start()
    {
        select = InputSystem.actions.FindAction("Select");
        select.performed += OnSelect; 
    }

    void OnSelect(InputAction.CallbackContext context) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100);
        if (hit.transform != transform) { return; }
        OnClick();
    }

    void OnDisable()
    {
        select.performed -= OnSelect;
    }
}
