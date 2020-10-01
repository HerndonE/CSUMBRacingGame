using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{

    public GameObject playerNCar;
   // public int size;
    public GameObject[] waypointObjects;

    // Start is called before the first frame update
    void Start()
    {
        //waypointObjects = new GameObject[size];
      
    }

    // Update is called once per frame
    void Update()
    {
        //WayPointFunction();   
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Wow Ethan!");
        //for(int i = 0; i < waypointObjects.Length; i++)
        //{
        //Debug.Log(i);
        if (playerNCar.gameObject == waypointObjects[0])
            {
                Debug.Log("Do Something");
            }
        //}
    }

}
