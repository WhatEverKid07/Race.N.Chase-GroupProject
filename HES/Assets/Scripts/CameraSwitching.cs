using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public GameObject CameraToSwitchTo;
    public GameObject CameraToSwitchFrom;
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            CameraToSwitchTo.SetActive(true);
            CameraToSwitchFrom.SetActive(false);
        }
        else
        {
            CameraToSwitchTo.SetActive(false);
            CameraToSwitchFrom.SetActive(true);
        }
    }
}
