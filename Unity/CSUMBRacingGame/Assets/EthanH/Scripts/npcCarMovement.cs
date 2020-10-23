/*
 * Ethan Herndon
 * 10/23/2020
*/
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class npcCarMovement : MonoBehaviour
{
    public int speed = 10;
    public string objectHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= speed * Vector3.left * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Wow Ethan!");
        if (other.gameObject.name == objectHit)
        {
            //Destroy(gameObject);
            transform.position = new Vector3(-347.3f, 2.3f, -142.69f);
        }

    }
}
