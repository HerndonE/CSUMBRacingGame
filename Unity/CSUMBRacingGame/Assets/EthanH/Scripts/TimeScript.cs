/*
 * Ethan Herndon
 * 10/15/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{

    public GameObject car; //This will be our player
    float time = 0.0f; 
    bool timeStarted = true; //Dictate when and how time is used in game
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStarted == true)
        {
            time += Time.deltaTime; //Incriment time as long as we are true
            //if (time >= 3.0f)
            if (gameObject.GetComponent<CheckPointSystem>().finished == false) //Check if the player the finished the course
            {
                //timerFunction();

                //Display information from the race and stop the time
                Debug.Log("Time: " + time);
                gameObject.GetComponent<CheckPointSystem>().addCoins += 50;
                Debug.Log("Coins: " + gameObject.GetComponent<CheckPointSystem>().addCoins);
                timeStarted = false;
            }
        }

    }

    void timerFunction()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.tag == "Pedestrian")
            {
                Debug.Log("Player has hit a pedestrian!");
                gameObject.GetComponent<CheckPointSystem>().addCoins--;
            }


    }


}
