using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyChangerMenu : MonoBehaviour
{
    private PoliceCarAI policeAI;
    private CarHealth carHealth;

    [Header("---Police Cars---")]
    public GameObject policeCar1;
    public GameObject policeCar2;
    public GameObject policeCar3;

    [Header("---Buttons---")]
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;
    public Button singleLifeButton;

    [SerializeField]
    public bool EasyBool = false;
    public bool NormalBool = false;
    public bool HardBool = false;
    public bool SingleLifeBool = false;

    private void Start()
    {
        EasyBool = false;
        NormalBool = false;
        HardBool = false;
        SingleLifeBool = false;

        Button Easy = easyButton.GetComponent<Button>();
        Button Normal = normalButton.GetComponent<Button>();
        Button Hard = hardButton.GetComponent<Button>();
        Button SingleLife = singleLifeButton.GetComponent<Button>();

        Easy.onClick.AddListener(EasyDifficulty);
        Normal.onClick.AddListener(NormalDifficulty);
        Hard.onClick.AddListener(HardDifficulty);
        SingleLife.onClick.AddListener(SingleLifeDifficulty);
    }

    void EasyDifficulty()
    {
        Debug.Log("Easy");
        carHealth.maxHealth = carHealth.maxHealth + 400;
        carHealth.maxBoost = carHealth.maxBoost + 700;
        carHealth.healthLose = carHealth.healthLose - 6;
        carHealth.PoliceHealthLose = carHealth.PoliceHealthLose - 30;
        policeAI.moveSpeed = policeAI.moveSpeed - 2;
    }
    void NormalDifficulty()
    {
        Debug.Log("Normal");
        carHealth.maxHealth = carHealth.maxHealth * 1;
        carHealth.maxBoost = carHealth.maxBoost * 1;
        carHealth.healthLose = carHealth.healthLose * 1;
        carHealth.PoliceHealthLose = carHealth.PoliceHealthLose * 1;
        policeAI.moveSpeed = policeAI.moveSpeed * 1;
    }
    void HardDifficulty()
    {
        Debug.Log("Hard");
        carHealth.maxHealth = carHealth.maxHealth - 400;
        carHealth.maxBoost = carHealth.maxBoost - 500;
        carHealth.healthLose = carHealth.healthLose + 20;
        carHealth.PoliceHealthLose = carHealth.PoliceHealthLose + 20;
        policeAI.moveSpeed = policeAI.moveSpeed + 3;
    }
    void SingleLifeDifficulty()
    {
        Debug.Log("Single Life");
        carHealth.maxHealth = carHealth.maxHealth - 790;
        carHealth.maxBoost = carHealth.maxBoost - 800;
        carHealth.healthLose = carHealth.healthLose * 1;
        policeCar1.SetActive(false);
        policeCar2.SetActive(false);
        policeCar3.SetActive(false);
    }
}
