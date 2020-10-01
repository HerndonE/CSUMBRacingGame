using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianAI : MonoBehaviour
{
    Rigidbody rb;

    public GameObject waypoints;

    public int currentWP;
    Transform currentT;

    public float speed;
    int randomDirection;
    bool freeze;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        freeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze) {
            currentT = waypoints.transform.GetChild(currentWP);

            transform.LookAt(new Vector3(currentT.position.x, transform.position.y, currentT.position.z));
            rb.velocity = transform.forward * speed;

            // Other Ways to Move (Creates a Hopping Effect)
            /*Vector3 rbv = rb.velocity;
            rbv.x = transform.forward.x * speed;
            rbv.z = transform.forward.z * speed;
            rb.velocity = rbv;*/

            //rb.AddForce(transform.forward * speed);

            // If Arrived at Waypoint
            if (Mathf.Abs(transform.position.x - currentT.position.x) < 0.2f && Mathf.Abs(transform.position.z - currentT.position.z) < 0.2f) {
                currentWP += randomDirection;

                if (currentWP >= 0) {
                    currentWP %= waypoints.transform.childCount;
                } else {
                    currentWP = waypoints.transform.childCount - 1;
                }
            }
        }
    }

    public void SetFreeze(bool freeze) {
        this.freeze = freeze;
    }
}
