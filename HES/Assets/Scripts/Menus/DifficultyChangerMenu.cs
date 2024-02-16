using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyChangerMenu : MonoBehaviour
{
    private PoliceCarAI policeAI;
    private CarHealth carHealth;
    private DifficultyChangerCar otherScript;

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
        EasyBool = true;
    }
    void NormalDifficulty()
    {
        Debug.Log("Normal");
        NormalBool = true;
    }
    void HardDifficulty()
    {
        Debug.Log("Hard");
        HardBool = true;
    }
    void SingleLifeDifficulty()
    {
        Debug.Log("Single Life");
        SingleLifeBool = true;
    }
}
