using UnityEngine;

public class Treadmill : MonoBehaviour
{
    Material material;
    [SerializeField] float treadmillSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetTextureOffset("_MainTex", material.GetTextureOffset("_MainTex") +  Vector2.right * Time.deltaTime * treadmillSpeed);
    }
}
