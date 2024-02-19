using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Assertions.Must;

public class CarHealth : MonoBehaviour
{
    [Header("Scripts")]
    public HealthBar healthBar;
    public BoostBar boostBar;
    public CarController controller;
    public PoliceCarAI policeAI;

    [Header("GameObjects")]
    public GameObject MainHUD;
    public GameObject DeathScreen;
    public GameObject PauseMenu;
    public GameObject smashedCar;
    public GameObject boostParticles;


    [Header("Car Health")]
    public int maxHealth;
    public int currentHealth;
    public int healthLose;
    public string TagToDealDamage;
    public AudioSource CarCrash;

    public string PoliceAITag;
    public int PoliceHealthLose;

    [Header("Car Boost")]
    public int maxBoost;
    public int currentBoost;
    public int boostLose;
    public AudioSource BoostSFX;

    void Start()
    {
        Time.timeScale = 1;
        currentBoost = maxBoost;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        boostBar.SetMaxBoost(maxBoost);
        boostParticles.SetActive(false);
    }

    void Update()
    {
        if(controller.isBoosting == true)
        {
            LoseBoost(boostLose);
            BoostSFX.Play();
            Debug.Log("BOOST");
        }
        else
        {
            boostParticles.SetActive(false);
            BoostSFX.Stop();
            Debug.Log("NO BOOST");
        }
        Death();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagToDealDamage))
        {
            TakeDamage(healthLose);
            CarCrash.Play();
        }
        if (collision.gameObject.CompareTag(PoliceAITag))
        {
            TakeDamage(PoliceHealthLose);
            CarCrash.Play();
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
        boostParticles.SetActive(true);
        boostBar.SetBoost(currentBoost);
    }

    void Death()
    {
        if (currentHealth < 1)
        {
            smashedCar.transform.position = gameObject.transform.position;
            smashedCar.transform.rotation = gameObject.transform.rotation;
            gameObject.GetComponent<CarController>().enabled = false;
            MainHUD.SetActive(false);
            DeathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            smashedCar.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
