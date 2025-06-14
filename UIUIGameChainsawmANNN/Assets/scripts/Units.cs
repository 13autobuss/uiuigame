using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public int health;
    public int maxHealth;
    public int shield;
    public int level;

    public Weapon Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }
    
    public virtual int Attack()
    {
        return weapon.SetDamage();
    }
    
    public void LevelUp(int healthRegen)
    {
        health += healthRegen;
    }
    
    public void GetHit(int damage)
    {
        health -= damage - shield;
    }
    
    public void GetHit(Weapon weapon)
    {
        health -= weapon.SetDamage() - shield;
    }
}
