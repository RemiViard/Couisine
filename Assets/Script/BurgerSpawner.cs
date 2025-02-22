using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BurgerSpawner : MonoBehaviour
{
    enum EState
    {
        Bot,
        Condiment1,
        Meat,
        Condiment2,
        Top,
        Score,
        Review,
    }
    EState state;
    InputAction drop;
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] GameObject drawerCondiment1;
    [SerializeField] GameObject drawerCondiment2;
    [SerializeField] GameObject drawerMeat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drop = InputSystem.actions.FindAction("Space");
        drop.performed += Drop;

    }
    private void OnEnable()
    {
        state = EState.Bot;
    }
    private void Drop(InputAction.CallbackContext obj)
    {
        GameObject gameObject = null;
        switch (state)
        {
            case EState.Bot:
                gameObject = Instantiate(ingredientManager.breadables[1].gameObject, transform);
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                if (gameObject.transform.childCount > 0)
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                break;
            case EState.Condiment1:
                drawerCondiment1.SetActive(true);
                break;
            case EState.Meat:
                drawerMeat.SetActive(true);
                break;
            case EState.Condiment2:
                drawerCondiment2.SetActive(true);
                break;
            case EState.Top:
                gameObject = Instantiate(ingredientManager.breadables[0].gameObject, transform);
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                if (gameObject.transform.childCount > 0)
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                break;
        }
        state++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
