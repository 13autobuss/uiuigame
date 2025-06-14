using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCuffsWeapon :  Weapon
{
    [SerializeField] private Player player;
    [SerializeField] private int scalingFactor;
    
    public override void ApplyEffect(Units target)
    {
        player = FindObjectOfType<Player>();
        int missingHealth = player.maxHealth - player.health;
        int damageBoost = (int)(((float)missingHealth / player.maxHealth) * scalingFactor);
        Debug.Log(damageBoost);
        target.GetHit(damageBoost);
    }
}
