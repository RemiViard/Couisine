using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum EType
    {
        ECuttable,
        ECookable,
        EBreadable
    }
    public List<Piece> pieces;
    public EType type;

}
