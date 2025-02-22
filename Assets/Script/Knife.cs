using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.Mathematics;

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

    InputAction cut;
    InputAction leftClick;
    InputAction rightClick;
    float lastMouseX;
    [SerializeField] Transform slicePivot;
    [SerializeField] Bin bin; 
    [SerializeReference] List<AudioSource> cutAudios = new List<AudioSource>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.y;

        cut = InputSystem.actions.FindAction("Space");
        cut.performed += Cut;
        leftClick = InputSystem.actions.FindAction("leftClick");
        rightClick = InputSystem.actions.FindAction("rightClick");
        ResetMouseX();
        endSlice.AddListener(ResetMouseX);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBusy)
        {
            timer += Time.deltaTime * cutSpeed;
            transform.position = new Vector3 { x = transform.position.x, z = transform.position.z, y = Mathf.Lerp(cutPos, startPos, Mathf.Abs(timer)) };
            if (timer >= 0 && !hasCut)
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
        else
        {
            //Move knife input
            if (lastMouseX != Input.mousePosition.x)
            {
                float newX = transform.position.x + (Input.mousePosition.x - lastMouseX) * Time.deltaTime * sensitivity;
                newX = Math.Clamp(newX, -1, 1);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                lastMouseX = Input.mousePosition.x;
            }
            float turnInput = 0;
            if (rightClick.IsPressed())
            {
                turnInput += 1;
            }
            if (leftClick.IsPressed())
            {
                turnInput += -1;
            }
            if (turnInput != 0)
            {
                float testedY = transform.eulerAngles.y + turnInput * rotationSensitivity;
                if (testedY <= 30 || testedY >= 330)
                    transform.Rotate(new Vector3(0, turnInput * rotationSensitivity, 0));
            }

        }
    }
    public void Cut()
    {
        if (!isBusy)
        {
            RandomAudioSource().Play();
            isBusy = true;
        }
    }
    void Slice()
    {
        List<RaycastHit> hits = new List<RaycastHit>();

        hits.AddRange(Physics.RaycastAll(slicePivot.position, slicePivot.forward, 1.2f));
        hits.AddRange(Physics.RaycastAll(slicePivot.position + Vector3.up * 0.05f, slicePivot.forward, 1.2f));
        hits.AddRange(Physics.RaycastAll(slicePivot.position + Vector3.up * 0.2f, slicePivot.forward, 1.2f));
        List<Collider> testedHits = new List<Collider>();
        if (hits.Count > 0)
        {
            foreach (var hit in hits)
            {
                if (!testedHits.Contains(hit.collider))
                    testedHits.Add(hit.collider);
            }
            foreach (var collider in testedHits)
            {
                if (collider.gameObject.CompareTag("Sliceable"))
                {
                    GameObject ingredient = Cutter.Cut(collider.gameObject, slicePivot.position, slicePivot.right);
                    if (ingredient != null)
                    {
                        if (collider.gameObject.name.Contains("Piece"))
                            ingredient.name = collider.gameObject.name;
                        else
                            ingredient.name = collider.gameObject.name + " Piece";
                        ingredient.tag = "Sliceable";
                        Piece piece = ingredient.AddComponent<Piece>();
                        piece.ingredient = collider.gameObject.GetComponent<Piece>().ingredient;
                        piece.ingredient.pieces.Add(piece);
                        piece.transform.parent = bin.transform;
                    }
                }
            }
        }
    }
    private void ResetMouseX()
    {
        lastMouseX = Input.mousePosition.x;
    }

    private void Cut(InputAction.CallbackContext obj)
    {
        Cut();
    }

    private AudioSource RandomAudioSource() {
        return cutAudios[UnityEngine.Random.Range(0, cutAudios.Count)];
    }
}