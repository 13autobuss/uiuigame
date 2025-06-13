using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;

    public int SetDamage()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }

    public abstract void ApplyEffect(Units target);
}
