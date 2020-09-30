using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public float turnSpeed;
    public float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Needed for Camera Smoothness
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    // Update is called once per frame
    void Update()
    {
        // Control Method 1 (No Momementum, slows down quickly)
        /*rb.velocity = transform.forward * Input.GetAxis("Vertical") * speed;
        rb.angularVelocity = transform.up * Input.GetAxis("Horizontal") * turnSpeed;*/

        // Control Method 2 (More Momementum Based, Hard to Turn (Spin out easily))
        /*rb.AddForce(transform.forward * Input.GetAxis("Vertical") * speed);
        rb.AddTorque(transform.up * Input.GetAxis("Horizontal") * turnSpeed);*/

        // Control Method 3 (Top Choice ATM, Good Balance of Both)
        rb.AddForce(transform.forward * Input.GetAxis("Vertical") * speed);
        if (rb.velocity.magnitude > 0.5) {
            rb.angularVelocity = transform.up * Input.GetAxis("Horizontal") * turnSpeed;
        }

        // Speed Boost
        if (Input.GetKey(KeyCode.E)) {
            rb.AddForce(transform.forward * Input.GetAxis("Vertical") * (speed / 2));
        }

        // Breaking
        if (Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(-transform.forward * Input.GetAxis("Vertical") * speed);
        }

        // Jumping (May Not Be in Final Product)
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Raycast length may need to be adjusted based on car height
            Physics.Raycast(transform.position, -transform.up, out RaycastHit rh, 0.5f);

            if (rh.transform != null) {
                rb.AddForce(transform.up * jumpSpeed);
            }
        }
    }
}
