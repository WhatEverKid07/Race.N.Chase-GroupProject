using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int randNum;
    public GameObject Barricade, BarricadeWRamp;

    void Start()
    {
        randNum = Random.Range(0, 3);
        if(randNum == 0) 
        {
            Barricade.SetActive(true);
            Debug.Log("Barricade");
        }

        if (randNum == 1)
        {
            BarricadeWRamp.SetActive(true);
            Debug.Log("BarricadeWRamp");
        }
    }

}
