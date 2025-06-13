using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string unitName;
    public int exp;

    public string UnitName
    {
        //Can only read this variable
        get { return unitName; }
    }
}
