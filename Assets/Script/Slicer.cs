using UnityEngine;

public class Slicer
{
    //private 
    private static GameObject CreateMeshGameObject(GameObject original)
    {
        
        Sliceable originalSliceable = original.GetComponent<Sliceable>();

        GameObject meshGameObject = new GameObject();

        meshGameObject.AddComponent<MeshFilter>();
        meshGameObject.AddComponent<MeshRenderer>();
        Sliceable sliceable = meshGameObject.AddComponent<Sliceable>();


        meshGameObject.GetComponent<MeshRenderer>().materials = original.GetComponent<MeshRenderer>().materials;

        meshGameObject.transform.position = original.transform.position;
        meshGameObject.transform.rotation = original.transform.rotation;
        meshGameObject.transform.localScale = original.transform.localScale;

        meshGameObject.tag = original.tag;

        return meshGameObject;
    }
}
