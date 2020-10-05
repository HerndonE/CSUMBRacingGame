using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{

    public GameObject playerNCar;
    public GameObject[] waypointObjects;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Wow Ethan!");

        for (int i = 0; i < waypointObjects.Length; i++)
        {
            if (other.gameObject == waypointObjects[i])
            {
                Debug.Log("Waypoint: " + i);
                Destroy(waypointObjects[i]);
                counter++;
            }

            if (counter == waypointObjects.Length)
            {
                Debug.Log("you made it!");
            }

        }
     
    }

}
