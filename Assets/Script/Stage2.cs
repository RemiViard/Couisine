using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Tuto tuto;
    [SerializeField] BoxCollider cuttingboardCollider;
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] Transform drawerCondimant;
    [SerializeField] Transform drawerCondimant2;
    private void Start()
    { 
    }
    private void OnEnable()
    {
        timer.SetTimer(30);
        timer.timerEnd.AddListener(OnTimerEnd);
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }
    void OnTimerEnd()
    {
        timer.timerEnd.RemoveListener(OnTimerEnd);
        NextStage();
    }
    void NextStage()
    {
        RaycastHit[] hits = Physics.BoxCastAll(cuttingboardCollider.transform.position, cuttingboardCollider.size / 2, cuttingboardCollider.transform.forward, cuttingboardCollider.transform.rotation, 0);
        if(hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if(hit.collider.gameObject.TryGetComponent(out Piece piece))
                {
                    if (piece.ingredient.id == ingredientManager.cuttables[0].id)
                    {
                        ingredientManager.condiment1.Add(piece);
                        piece.transform.parent = drawerCondimant;
                    }                    
                    else
                    {
                        ingredientManager.condiment2.Add(piece);
                        piece.transform.parent = drawerCondimant2;
                    }
                    piece.transform.localPosition = Vector3.zero;
                }
            }
        }
        gameObject.SetActive(false);
        tuto.ShowTuto(2);
    }
}
