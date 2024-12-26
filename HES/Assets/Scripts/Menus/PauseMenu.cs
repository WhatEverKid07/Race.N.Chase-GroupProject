using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public AudioSource PoliceSiren;
    public AudioSource PoliceSiren2;
    public AudioSource PoliceSiren3;
    public GameObject pauseMenu;
    public static bool gameIsPaused = false;

    private CarController carController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        PoliceSiren.UnPause();
        PoliceSiren2.UnPause();
        PoliceSiren3.UnPause();
        //carController.carEngine.UnPause();
    }
       
    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        PoliceSiren.Pause();
        PoliceSiren2.Pause();
        PoliceSiren3.Pause();
        //carController.carEngine.Pause();
    }
}
