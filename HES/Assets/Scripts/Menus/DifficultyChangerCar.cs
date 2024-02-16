using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChangerCar : MonoBehaviour
{
    private PoliceCarAI policeAI;
    private CarHealth carHealth;
    private DifficultyChangerMenu otherScript;

    [Header("---Police Cars---")]
    public GameObject policeCar1;
    public GameObject policeCar2;
    public GameObject policeCar3;

    private void Update()
    {
        if(otherScript.EasyBool == true)
        {
            EasyDifficulty();
        }
        if (otherScript.NormalBool == true)
        {
            NormalDifficulty();
        }
        if (otherScript.HardBool == true)
        {
            HardDifficulty();
        }
        if (otherScript.SingleLifeBool == true)
        {
            SingleLifeDifficulty();
        }
    }
    void EasyDifficulty()
    {
        Debug.Log("Easy 2");
        carHealth.maxHealth = carHealth.maxHealth + 400;
        carHealth.maxBoost = carHealth.maxBoost + 700;
        carHealth.healthLose = carHealth.healthLose - 6;
        carHealth.PoliceHealthLose = carHealth.PoliceHealthLose - 30;
        policeAI.moveSpeed = policeAI.moveSpeed - 2;
    }
    void NormalDifficulty()
    {
        Debug.Log("Normal 2");
        carHealth.maxHealth = carHealth.maxHealth * 1;
        carHealth.maxBoost = carHealth.maxBoost * 1;
        carHealth.healthLose = carHealth.healthLose * 1;
        carHealth.PoliceHealthLose = carHealth.PoliceHealthLose * 1;
        policeAI.moveSpeed = policeAI.moveSpeed * 1;
    }
    void HardDifficulty()
    {
        Debug.Log("Hard 2");
        carHealth.maxHealth = carHealth.maxHealth - 400;
        carHealth.maxBoost = carHealth.maxBoost - 500;
        carHealth.healthLose = carHealth.healthLose + 20;
        carHealth.PoliceHealthLose = carHealth.PoliceHealthLose + 20;
        policeAI.moveSpeed = policeAI.moveSpeed + 3;
    }
    void SingleLifeDifficulty()
    {
        Debug.Log("Single Life 2");
        carHealth.maxHealth = carHealth.maxHealth - 790;
        carHealth.maxBoost = carHealth.maxBoost - 800;
        carHealth.healthLose = carHealth.healthLose * 1;
        policeCar1.SetActive(false);
        policeCar2.SetActive(false);
        policeCar3.SetActive(false);
    }
}
