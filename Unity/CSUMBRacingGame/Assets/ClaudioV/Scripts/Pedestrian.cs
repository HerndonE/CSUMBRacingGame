using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    Rigidbody rb;

    // Waypoint System
    Transform waypointLoop;
    public int currentWP;
    Transform currentT;

    // Pedestrian Info
    public float speed;
    public float jumpSpeed;
    int direction;
    int walkStyle;
    int carReaction;

    bool freeze;
    bool chase;

    // Setup Pedestrian Info
    public void SpawnPedestrian(Transform waypointLoop, int currentWP) {
        this.waypointLoop = waypointLoop;
        this.currentWP = currentWP;
        currentT = waypointLoop.transform.GetChild(currentWP);

        speed = Random.Range(2, 9);
        direction = Random.Range(0, 2) == 0 ? -1 : 1;
        walkStyle = 0;
        carReaction = Random.Range(0, 3);

        if (carReaction != 2) {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

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
            } else { // Hopping (Doesn't work with New Models)
                Vector3 rbv = rb.velocity;
                rbv.x = transform.forward.x * speed;
                rbv.z = transform.forward.z * speed;
                rb.velocity = rbv;
            }

            // If Arrived at Waypoint
            if (Mathf.Abs(transform.position.x - currentT.position.x) < 0.2f && Mathf.Abs(transform.position.z - currentT.position.z) < 0.2f) {
                currentWP += direction;

                if (currentWP >= 0) {
                    currentWP %= waypointLoop.childCount;
                } else {
                    currentWP = waypointLoop.childCount - 1;
                }

                currentT = waypointLoop.GetChild(currentWP);
            }
        }
    }

    // React to Car (Depends on Type of Reaction & the Trigger)
    public void CarReact(string trigger, Transform player) {
        if (carReaction == 0 && trigger == "enterPlayer") { // Jump
            rb.AddForce(transform.up * jumpSpeed);
        } else if (carReaction == 1 && trigger.Contains("Player")) { // Freeze
            freeze = freeze == false;
        } else if (carReaction == 2 && trigger.Contains("Pedestrian")) { // Chase Car
            chase = chase == false;

            if (chase) {
                currentT = player;
            } else {
                currentT = waypointLoop.GetChild(currentWP);
            }
        }
    }
}
