using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int agroGain;
   
    public override int Attack()
    {
        aggression += agroGain;
        return Weapon.SetDamage()+ aggression / 10;
    }
}
