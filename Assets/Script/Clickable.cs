using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clickable : MonoBehaviour
{
    private InputAction select;
    public event Action OnClick;

    void Start()
    {
        select = InputSystem.actions.FindAction("LeftClick");
        select.performed += OnSelect; 
    }

    void OnSelect(InputAction.CallbackContext context) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100);
        if (hit.transform != transform) { return; }
        OnClick?.Invoke();
    }

    void OnDisable()
    {
        select.performed -= OnSelect;
    }
}
