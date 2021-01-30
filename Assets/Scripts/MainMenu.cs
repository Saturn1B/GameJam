using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu, Credit;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void LaunchCredit()
    {
        Menu.SetActive(false);
        Credit.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        Credit.SetActive(false);
        Menu.SetActive(true);
    }
}
