using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameModes;

    public static string gameMode;

    private void Start() 
    {
        gameModes.SetActive(false);
    }

    public void StartGame() 
    {
        mainMenu.SetActive(false);
        gameModes.SetActive(true);
    }

    public void PlayRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameMode = "Race";
    }

    public void PlayFreeRoam() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameMode = "FreeRoam";
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void BackButton() 
    {
        mainMenu.SetActive(true);
        gameModes.SetActive(false);
    }

}
