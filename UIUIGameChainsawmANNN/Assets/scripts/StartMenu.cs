using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Player player;
    [SerializeField] private Weapon feather, cuffs, scraper;

    public void ChooseFeather()
    {
        player.Weapon = feather;
        gameManager.Game.SetActive(true);
        gameManager.StartMenu.SetActive(false);
    }

    public void ChooseScraper()
    {
        player.Weapon = scraper;
        gameManager.Game.SetActive(true);
        gameManager.StartMenu.SetActive(false);
    }

    public void ChooseCuffs()
    {
        player.Weapon = cuffs;
        gameManager.Game.SetActive(true);
        gameManager.StartMenu.SetActive(false);
    }
}
