using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    //Create slider for Health Bar
    public Slider healthBar;
    //Create variable for enemy
    public Slider enemyHealthBarUI;
    //Create variable for health
    public int health = 100;
    //Create variable for damage
    public int damage = 10;
    //Get variable for health button
    public Button healthButton;
    //Get variable for damage button
    public Button damageButton;
    //Create variable for Panel
    public GameObject VictoryPanel;

    public bool firstState = false;
    public bool secondState = false;
    public bool thirdState = false;

    // Start is called before the first frame update
    void Start()
    {
        //Set both health bars to 100
        healthBar.value = health;
        enemyHealthBarUI.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the enemyHealthBarUI is at 80% health if so, then the enemyHealthBarUI gains 20% health. It only happens once.
        if (enemyHealthBarUI.value == 80 && firstState == false)
        {
            enemyHealthBarUI.value += 20;
            firstState = true;
            //Give a random damage between 30 and 60 to the player
            health -= Random.Range(30, 60);
            //Set the health bar to the player's health
            healthBar.value = health;
        }
        //Check if the enemyHealthBarUI is at 60% health if so, then the enemyHealthBarUI gains 20% health. It only happens once.
        if (enemyHealthBarUI.value == 60 && secondState == false)
        {
            enemyHealthBarUI.value += 20;
            secondState = true;
            //Give a random damage between 30 and 60 to the player
            health -= Random.Range(10, 40);
            //Set the health bar to the player's health
            healthBar.value = health;
        }
        //Check if the enemyHealthBarUI is at 40% health if so, then the enemyHealthBarUI gains 20% health. It only happens once.
        if (enemyHealthBarUI.value == 40 && thirdState == false)
        {
            enemyHealthBarUI.value += 20;
            thirdState = true;
            //Give a random damage between 30 and 60 to the player
            health -= Random.Range(30, 60);
            //Set the health bar to the player's health
            healthBar.value = health;
        }
        //Check if the player's health is less than or equal to 0, if so, then the player's health is 0.
        if (health <= 0)
        {
            health = 0;
        }
        //Check if enemy health is less than 0 or equal to 0, if so, stop the game.
        if (enemyHealthBarUI.value <= 0)
        {
            //Make the Victory Panel appear
            VictoryPanel.SetActive(true);
        }
        //Give every 5 seconds a random damage between 10 and 20 to the player
        if (Time.time % 5 == 0)
        {
            health -= Random.Range(10, 30);
            //Set the health bar to the player's health
            healthBar.value = health;
        }
    }

    public void HealthButton()
    {
        //When the player clicks the health button, the player's health bar increases by 5 points.
        health += 5;
        healthBar.value = health;
    }

    public void DamageButton()
    {
        //When the player clicks the damage button, the enemy's health bar decreases by 5 points.
        enemyHealthBarUI.value -= damage;
    }

    public int getHealth()
    {
        return health;
    }

    public int getEnemyHealth()
    {
        return (int)enemyHealthBarUI.value;
    }

    //Create method for button to go to Main Menu
    public void MainMenu()
    {
        //Load Main Menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
