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
    }
    EState state;
    InputAction drop;
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] GameObject drawerCondiment1;
    [SerializeField] GameObject drawerCondiment2;
    [SerializeField] GameObject drawerMeat;
    [SerializeField] ScoreUI scoreUi;
    [SerializeField] Bin bin;
    private void OnEnable()
    {
        drop = InputSystem.actions.FindAction("Space");
        state = EState.Bot;
        drop.performed += Drop;
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
                gameObject.transform.parent = bin.transform;
                ScoreManager.AddScore(gameObject.GetComponent<Ingredient>().scoreValue);
                if (gameObject.transform.childCount > 0)
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                break;
            case EState.Condiment1:
                drawerCondiment1.SetActive(true);
                
                for (int i = drawerCondiment1.transform.childCount-1; i >= 0; i--)
                {
                    Ingredient ingredient = drawerCondiment1.transform.GetChild(i).GetComponent<Ingredient>();
                    ingredient.transform.parent = bin.transform;
                    ScoreManager.AddScore(ingredient.scoreValue);
                }
                break;
            case EState.Meat:
                drawerMeat.SetActive(true);
                for (int i = drawerMeat.transform.childCount - 1; i >= 0; i--)
                {
                    Ingredient ingredient = drawerMeat.transform.GetChild(i).GetComponent<Ingredient>();
                    ingredient.transform.parent = bin.transform;
                    ScoreManager.AddScore(ingredient.scoreValue);
                }
                break;
            case EState.Condiment2:
                drawerCondiment2.SetActive(true);
                for (int i = drawerCondiment2.transform.childCount - 1; i >= 0; i--)
                {
                    Ingredient ingredient = drawerCondiment2.transform.GetChild(i).GetComponent<Ingredient>();
                    ingredient.transform.parent = bin.transform;
                    ScoreManager.AddScore(ingredient.scoreValue);
                }
                break;
            case EState.Top:
                gameObject = Instantiate(ingredientManager.breadables[0].gameObject, transform);
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.transform.parent = bin.transform;
                ScoreManager.AddScore(gameObject.GetComponent<Ingredient>().scoreValue);
                if (gameObject.transform.childCount > 0)
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                break;
            case EState.Score:
                if (!scoreUi.active)
                    scoreUi.ShowScore();
                else
                    scoreUi.ReceaveInput();
                state--;
                break;
        }
        state++;
    }
    private void OnDisable()
    {
        drop.performed -= Drop;
    }
}
