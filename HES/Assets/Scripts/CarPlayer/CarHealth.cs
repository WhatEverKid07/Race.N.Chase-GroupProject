using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public BoostBar boostBar;
    public CarController controller;

    public GameObject MainHUD;
    public GameObject DeathScreen;
    public GameObject PauseMenu;

    [Header("Car Health")]
    public int maxHealth;
    public int currentHealth;
    public int healthLose;
    public string TagToDealDamage;

    [Header("Car Boost")]
    public int maxBoost;
    public int currentBoost;
    public int boostLose;

    void Start()
    {
        Time.timeScale = 1;
        currentBoost = maxBoost;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        boostBar.SetMaxBoost(maxBoost);

    }

    void Update()
    {
        if(controller.isBoosting == true)
        {
            LoseBoost(boostLose);
        }
        Death();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagToDealDamage))
        {
            TakeDamage(healthLose);
        }
    }

    void TakeDamage(int damaged)
    {
        currentHealth -= damaged;

        healthBar.SetHealth(currentHealth);
    }

    void LoseBoost(int damaged)
    {
        currentBoost -= damaged;

        boostBar.SetBoost(currentBoost);
    }

    void Death()
    {
        if (currentHealth < 1)
        {
            Time.timeScale = 0;
            MainHUD.SetActive(false);
            DeathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
