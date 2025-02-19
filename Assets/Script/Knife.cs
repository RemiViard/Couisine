using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    public UnityEvent endSlice;
    public float sensitivity;
    public float rotationSensitivity;
    float startPos;
    public float cutPos;
    public float cutSpeed;
    [NonSerialized] public bool isBusy = false;
    float timer = -1;
    bool hasCut = false;
    [SerializeField] Transform slivePivot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBusy)
        {
            timer += Time.deltaTime * cutSpeed;
            transform.position = new Vector3 { x = transform.position.x, z = transform.position.z, y = Mathf.Lerp(cutPos, startPos, Mathf.Abs(timer))};
            if(timer >= 0 && !hasCut)
            {
                hasCut = true;
                Slice();
            }
            if (timer >= 1)
            {
                transform.position = new Vector3 { x = transform.position.x, y = startPos, z = transform.position.z };
                timer = -1;
                isBusy = false;
                hasCut = false;
                endSlice.Invoke();
            }

        }
    }
    public void Cut()
    {
        if (!isBusy)
        {
            isBusy = true;
        }
    }
    void Slice()
    {
        RaycastHit[] hits = Physics.RaycastAll(slivePivot.position, slivePivot.forward, 0.7f);
        Debug.Log(hits.Length);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.CompareTag("Sliceable"))
                {
                    GameObject ingredient = Cutter.Cut(hit.collider.gameObject, slivePivot.position, slivePivot.right);
                    Debug.Log(ingredient);
                    if(ingredient != null)
                    {
                        if (hit.collider.gameObject.name.Contains("Piece"))
                            ingredient.name = hit.collider.gameObject.name;
                        else
                            ingredient.name = hit.collider.gameObject.name + " Piece";
                        ingredient.tag = "Sliceable";
                        Piece piece = ingredient.AddComponent<Piece>();
                        piece.ingredient = hit.collider.gameObject.GetComponent<Piece>().ingredient;
                        piece.ingredient.pieces.Add(piece);
                    }
                }
            }
        }
    }
        
        
}