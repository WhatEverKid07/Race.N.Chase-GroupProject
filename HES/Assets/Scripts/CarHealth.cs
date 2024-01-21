using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public BoostBar boostBar;
    public CarController controller;


    [Header("Car Health")]
    public int maxHealth;
    public int currentHealth;
    public int healthLose;

    [Header("Car Boost")]
    public int maxBoost;
    public int currentBoost;
    public int boostLose;

    void Start()
    {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
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
}
