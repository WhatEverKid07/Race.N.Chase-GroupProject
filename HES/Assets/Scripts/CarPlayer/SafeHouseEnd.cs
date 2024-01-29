using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeHouseEnd : MonoBehaviour
{
    public string safeHouseTag;
    //public string endScene;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(safeHouseTag))
        {
            SceneManager.LoadScene("End Menu");
        }
    }
}
