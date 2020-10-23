/*
 * Ethan Herndon
 * 10/23/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnVehicles : MonoBehaviour
{
    public GameObject otterExpress;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(otterExpress, new Vector3(-347.3f, 2.3f, -142.69f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
