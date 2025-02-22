using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stage1Selector : MonoBehaviour
{
    InputAction select;
    GameObject currentObject = null;
    [SerializeField] Stage1Basket stage1Basket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        select = InputSystem.actions.FindAction("Space");
        select.performed += SelectObject;
    }

    private void SelectObject(InputAction.CallbackContext obj)
    {
        if (currentObject != null)
            stage1Basket.AddItem(currentObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentObject = other.gameObject)
            currentObject = null;
    }
    private void OnDisable()
    {
        select.performed -= SelectObject;
    }
}
