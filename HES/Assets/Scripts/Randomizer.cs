using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    int randNum;
    public GameObject Barricade1, Barricade2, Barricade3, Barricade4;

    void Start()
    {
        randNum = Random.Range(1, 5);
        if(randNum == 1)
        {
            Barricade1.SetActive(true);
        }
        if (randNum == 2)
        {
            Barricade2.SetActive(true);
        }
        if (randNum == 3)
        {
            Barricade3.SetActive(true);
        }
        if (randNum == 4)
        {
            Barricade4.SetActive(true);
        }
    }

}
