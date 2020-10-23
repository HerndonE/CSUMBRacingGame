/*
 * Ethan Herndon
 * 10/15/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{

    public GameObject playerNCar;
    public GameObject[] waypointObjects;
    private int counter = 0;
    public int addCoins = 0;
    public Text coinText;
    public Text lapText;
    public Text youWon;
    public bool finished = true;
    public int lapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        addCoins = 0;
        finished = true;
        lapCount = 0;

        if (MainMenu.gameMode == "Race") {
            lapText.text = "Lap: " + lapCount.ToString() + "/3";
        } else {
            lapText.text = "";

            for (int i = 0; i < waypointObjects.Length; i++) {
                waypointObjects[i].SetActive(false);
            }
        }
        youWon.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            youWon.GetComponent<Text>().enabled = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Wow Ethan!");
        if (MainMenu.gameMode == "Race") {

            for (int i = 0; i < waypointObjects.Length; i++) {
                if (other.gameObject == waypointObjects[i]) {
                    Debug.Log("Waypoint: " + i);
                    //Destroy(waypointObjects[i]);
                    waypointObjects[i].SetActive(false);
                    counter++;
                    addCoins++;
                    Debug.Log("Coin count: " + addCoins);
                    coinText.text = "Coins: " + addCoins;
                }

                if (counter == waypointObjects.Length) {

                    counter = 0;
                    lapCount++;
                    Debug.Log("Lap Count: " + lapCount);
                    lapText.text = "Lap: " + lapCount.ToString() + "/3";
                    for (int j = 0; j < waypointObjects.Length; j++) {
                        waypointObjects[j].SetActive(true);
                    }


                    if (lapCount == 3) {
                        finished = false;
                        Debug.Log("you made it!");
                        Debug.Log("finished: " + finished);
                        youWon.GetComponent<Text>().enabled = true;
                        Time.timeScale = 0;

                    }


                }

            }
        }
     
    }

}
