using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Units
{
    [SerializeField] private string unitName;
    public int exp;

    public string UnitName
    {
        get { return unitName; }
    }
}
