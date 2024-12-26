using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public AudioSource menuMusic;
    void Start()
    {
        menuMusic.Play();
    }
}
