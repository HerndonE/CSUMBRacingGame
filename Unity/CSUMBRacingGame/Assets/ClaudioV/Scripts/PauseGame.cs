using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;

    bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        Time.timeScale = 1;

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pause = !pause;

            if (pause) {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            } else {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void MenuButton() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGameButton() {
        Application.Quit();
    }
}
