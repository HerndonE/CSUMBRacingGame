/*
 * Ethan Herndon
 * 10/15/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeScript : MonoBehaviour
{

    public GameObject car; //This will be our player
    float time = 0.0f; 
    bool timeStarted = true; //Dictate when and how time is used in game
    public Text coinText;
    public Text timeText;
    public Text firstLap;
    public Text secondLap;
    public Text thirdLap;
    float one = 0.0f;
    float two = 0.0f;
    float three = 0.0f;
    bool timeStartedOne = false;
    bool timeStartedTwo = false;
    bool timeStartedThree = false;
    bool timeFinishedOne = false;
    bool timeFinishedTwo = false;
    bool timeFinishedThree = false;
    public int coinPenalty = 1;

    // Start is called before the first frame update
    void Start()
    {
        one = 0.0f;
        two = 0.0f;
        three = 0.0f;
        timeStartedOne = false;
        timeStartedTwo = false;
        timeStartedThree = false;
        timeFinishedOne = false;
        timeFinishedTwo = false;
        timeFinishedThree = false;
        coinPenalty = 1;

        if (MainMenu.gameMode == "Race") {
            coinText.text = "Coins: 0";
            firstLap.text = "Lap 1 Time: " + one.ToString("F2");
            secondLap.text = "Lap 2 Time: " + two.ToString("F2");
            thirdLap.text = "Lap 3 Time: " + three.ToString("F2");
        } else {
            coinText.text = "";
            firstLap.text = "";
            secondLap.text = "";
            thirdLap.text = "";
            timeText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.gameMode == "Race") {
            if (timeStarted == true) {
                time += Time.deltaTime; //Incriment time as long as we are true
                timeText.text = "Time: " + time.ToString("F2");
                timeStartedOne = true;
                //if (time >= 3.0f)
                if (gameObject.GetComponent<CheckPointSystem>().finished == false) //Check if the player the finished the course
                {
                    //timerFunction();

                    //Display information from the race and stop the time
                    Debug.Log("Time: " + time);
                    timeStarted = false;
                }
            }

            if (gameObject.GetComponent<CheckPointSystem>().lapCount == 1 && timeFinishedOne == false) {
                firstLap.text = "Lap 1 Time: " + one.ToString("F2");
                timeStartedOne = false;
                time = 0;
                timeFinishedOne = true;
                timeStartedTwo = true;
                coinFunction();

            }

            if (gameObject.GetComponent<CheckPointSystem>().lapCount == 2 && timeFinishedTwo == false) {
                secondLap.text = "Lap 2 Time: " + two.ToString("F2");
                timeStartedTwo = false;
                time = 0;
                timeFinishedTwo = true;
                timeStartedThree = true;
                coinFunction();
            }

            if (gameObject.GetComponent<CheckPointSystem>().lapCount == 3 && timeFinishedThree == false) {
                thirdLap.text = "Lap 3 Time: " + three.ToString("F2");
                timeStartedThree = false;
                time = 0;
                timeFinishedThree = true;
                coinFunction();

            }

            if (timeStartedOne == true) {
                one += Time.deltaTime;
            }

            if (timeStartedTwo == true) {
                two += Time.deltaTime;
            }

            if (timeStartedThree == true) {
                three += Time.deltaTime;
            }
        }
    }

    void coinFunction()
    {
        gameObject.GetComponent<CheckPointSystem>().addCoins += 50;
        coinText.text = "Coins: " + gameObject.GetComponent<CheckPointSystem>().addCoins;
        Debug.Log("Coins: " + gameObject.GetComponent<CheckPointSystem>().addCoins);

        if (gameObject.GetComponent<CheckPointSystem>().addCoins < (50 * gameObject.GetComponent<CheckPointSystem>().lapCount))
        {
            coinPenalty--;
            if(coinPenalty < 0)
            {
                coinPenalty = 0;
            }

        }

        else if (gameObject.GetComponent<CheckPointSystem>().addCoins >= (50 * gameObject.GetComponent<CheckPointSystem>().lapCount))
        {
            coinPenalty++;
        }

    }

    void OnTriggerEnter(Collider other)
    {

        
            if (other.gameObject.tag == "Pedestrian" && MainMenu.gameMode == "Race")
            {
                Debug.Log("Player has hit a pedestrian!");
                Debug.Log("Coin Penalty: " + coinPenalty);
                gameObject.GetComponent<CheckPointSystem>().addCoins = gameObject.GetComponent<CheckPointSystem>().addCoins - coinPenalty;
                coinText.text = "Coins: " + gameObject.GetComponent<CheckPointSystem>().addCoins;
        }


    }


}
