using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    int randNum;
    public GameObject Barricade, BarricadeWRamp, NoRamp;

    void Start()
    {
        randNum = Random.Range(1, 4);
        if(randNum == 2)
        {
            Barricade.SetActive(true);
        }
        if (randNum == 3)
        {
            BarricadeWRamp.SetActive(true);
        }
        if (randNum == 1)
        {
            NoRamp.SetActive(true);
        }
    }

}
