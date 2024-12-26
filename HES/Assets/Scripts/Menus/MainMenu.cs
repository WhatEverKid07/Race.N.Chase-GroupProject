using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string Scene;

    public void OpenScene()
    {
        SceneManager.LoadScene(Scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
