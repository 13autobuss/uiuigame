using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootScraper : Weapon
{
    private int turnCount;
    
    public override void ApplyEffect(Units target)
    {
        turnCount += 1;

        if (turnCount >= 3)
        {
            target.GetHit(30);
            turnCount = 0;
        }
    }
}
