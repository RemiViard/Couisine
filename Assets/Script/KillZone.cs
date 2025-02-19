using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            Destroy(ingredient.gameObject);
        }
    }
}
