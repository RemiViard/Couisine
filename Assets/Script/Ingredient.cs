using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int id;
    public enum EType
    {
        ECuttable,
        ECookable,
        EBreadable
    }
    public List<Piece> pieces;
    public EType type;

}
