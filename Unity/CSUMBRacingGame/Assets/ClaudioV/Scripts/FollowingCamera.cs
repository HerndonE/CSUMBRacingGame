using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject player;
    public Transform camTransform;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Update Camera Follow Point to Camera 
        //camTransform.position = transform.position;
        //camTransform.rotation = transform.rotation;

        // Update Camera to Camera Follow Point
        transform.position = camTransform.position;
        transform.rotation = camTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Fixed Camera
        //transform.position = camTransform.position;

        //Smooth Camera
        transform.position = Vector3.SmoothDamp(transform.position, camTransform.position, ref velocity, 0.15f);

        transform.rotation = camTransform.rotation;
    }
}
