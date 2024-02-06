using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarVariation : MonoBehaviour
{
    int randNum;
    public GameObject Car1, Car2, Car3;

    void Start()
    {
        randNum = Random.Range(0, 6);
        if(randNum == 0)
        {
            Car1.SetActive(true);
        }
        if (randNum == 1)
        {
            Car2.SetActive(true);
        }
        if (randNum == 2)
        {
            Car3.SetActive(true);
        }
    }

}
