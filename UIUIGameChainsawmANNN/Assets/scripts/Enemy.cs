using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Units
{
    [SerializeField] private string enemyName;
    [SerializeField] public Sprite imagee;
    [SerializeField] protected int aggression = 5;
    public int experienceAmmount;
    
    public string EnemyName
    {
        get { return enemyName; }
    }
}
