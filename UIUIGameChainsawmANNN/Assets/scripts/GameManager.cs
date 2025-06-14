using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName, playerHealth,level, enemyName, enemyHealth, ShieldText, enemyWeapon;
    [SerializeField] private Image enemyImage;
    public GameObject ShieldButton, StartMenu, WinScreen, LooseScreen, Game;
    [SerializeField] private int healAmount;
    [SerializeField] private AudioSource attack, sniff, bgm;
    
    
    private bool gameIsActive;
    private int currentEnemy;
    private bool shieldOn;
    private int shieldDurability = 0;
    private bool hasHealed;
    
    public Player player;
    public Enemy[] enemy;

    private void Start()
    {
        bgm.Play();
        StartMenu.SetActive(true);
        WinScreen.SetActive(false);
        LooseScreen.SetActive(false);
        Game.SetActive(false);
        
        player.maxHealth = player.health;
        gameIsActive = true;
        currentEnemy = 0;
        UpdateStats();
    }

    private void Update()
    {
        if (player.exp >= 10)
        {
            player.LevelUp(20);
            player.health = player.maxHealth;
            player.level += 1;
            player.exp -= 10;
            UpdateStats();
        }
        
        if (shieldDurability == 3)
        {
            player.shield = 0;
            shieldOn = false;
            ShieldButton.SetActive(false);
        }
        
        if (shieldOn)
        {
            player.shield = 10;
            ShieldText.text = "Shield is on!!!";
        }
        else
        {
            player.shield = 0;
            ShieldText.text = "Shield is off!!!";
        } 
        
        CheckEnemyStatus();
        if (player.health <= 0)
        {
            Game.SetActive(false);
            gameIsActive = false;
            LooseScreen.SetActive(true);
        }
        
    }

    public void DoRoundAttack()
    {
        
        if (gameIsActive)
        {
            attack.Play();
            if (shieldOn)
            { 
                shieldDurability = Random.Range(0,5);
            }
            
            player.GetHit(enemy[currentEnemy].Weapon);
            enemy[currentEnemy].Weapon.ApplyEffect(player);
            enemy[currentEnemy].GetHit(player.Weapon);
            player.Weapon.ApplyEffect(enemy[currentEnemy]);
            UpdateStats();
        }
    }
    
    public void DoRoundHeal()
    {
        if (gameIsActive)
        {
            sniff.Play();
            if (shieldOn)
            { 
                shieldDurability = Random.Range(0,5);
            }
            
            player.GetHit(enemy[currentEnemy].Weapon);
            enemy[currentEnemy].Weapon.ApplyEffect(player);
            
            if (hasHealed)
            {
                hasHealed = false;
                UpdateStats();
                return;
            }
            player.health += healAmount;
            hasHealed = true;
            
            UpdateStats();
        }
    }
    
    private void CheckEnemyStatus()
    {
        if(enemy[currentEnemy].health <= 0 && gameIsActive)
        {
            if (currentEnemy < enemy.Length -1)
            {
                player.exp += enemy[currentEnemy].experienceAmmount;
                currentEnemy += 1;
                enemyName.text = enemy[currentEnemy].name;
                UpdateStats();
            }
            else
            {
                gameIsActive = false;
                Game.SetActive(false);
                WinScreen.SetActive(true);
            }
        }
    }
    
    public void Shield()
    {
        shieldOn = !shieldOn;
    }
    
    public void UpdateStats()
    {
        enemyImage.sprite = enemy[currentEnemy].imagee;
        enemyName.text = enemy[currentEnemy].EnemyName;
        enemyWeapon.text = enemy[currentEnemy].Weapon.name;
        playerHealth.text = player.health.ToString();
        playerName.text = player.UnitName;
        enemyHealth.text = enemy[currentEnemy].health.ToString();
        level.text = "Level: " + player.level;
    }
}
