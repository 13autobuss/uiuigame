using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public int health;
    public int shield;
    public int level;

    public Weapon Weapon
    {
        get { return weapon; }
    }
    
    public virtual int Attack()
    {
        return weapon.SetDamage();
    }
    
    public void LevelUp(int healthRegen)
    {
        health += healthRegen;
    }
    
    public void GetHit(Weapon weapon)
    {
        health -= weapon.SetDamage() - shield;
    }
}
