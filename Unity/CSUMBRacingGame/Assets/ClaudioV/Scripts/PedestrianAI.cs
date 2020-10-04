using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianAI : MonoBehaviour
{
    Rigidbody rb;

    // Waypoint System
    public GameObject waypoints;
    public int currentWP;
    Transform currentT;

    // Pedestrian Info
    public float speed;
    int direction;
    int walkStyle;
    int carReaction;

    bool freeze;
    bool chase;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = Random.Range(2, 9);
        direction = Random.Range(0, 2) == 0 ? -1 : 1;
        walkStyle = Random.Range(0, 2);
        carReaction = Random.Range(0, 3);

        currentT = waypoints.transform.GetChild(currentWP);

        if (carReaction != 2) {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        freeze = false;
        chase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze) {
            transform.LookAt(new Vector3(currentT.position.x, transform.position.y, currentT.position.z));

            if (walkStyle == 0) { // Regular Walking
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            } else { // Hopping
                Vector3 rbv = rb.velocity;
                rbv.x = transform.forward.x * speed;
                rbv.z = transform.forward.z * speed;
                rb.velocity = rbv;
            }

            // If Arrived at Waypoint
            if (Mathf.Abs(transform.position.x - currentT.position.x) < 0.2f && Mathf.Abs(transform.position.z - currentT.position.z) < 0.2f) {
                currentWP += direction;

                if (currentWP >= 0) {
                    currentWP %= waypoints.transform.childCount;
                } else {
                    currentWP = waypoints.transform.childCount - 1;
                }

                currentT = waypoints.transform.GetChild(currentWP);
            }
        }
    }

    public void CarReact(string trigger, Transform player) {
        if (carReaction == 0 && trigger == "enterPlayer") { // Jump
            rb.AddForce(transform.up * 450);
        } else if (carReaction == 1 && trigger.Contains("Player")) { // Freeze
            freeze = freeze == false;
        } else if (carReaction == 2 && trigger.Contains("Pedestrian")) { // Chase Car
            chase = chase == false;

            if (chase) {
                currentT = player;
            } else {
                currentT = waypoints.transform.GetChild(currentWP);
            }
        }
    }

}
