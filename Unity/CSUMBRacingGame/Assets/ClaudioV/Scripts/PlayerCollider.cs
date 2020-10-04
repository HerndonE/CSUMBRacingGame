using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public float pedestrianJumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pedestrian")) {
            other.GetComponent<PedestrianAI>().CarReact("enterPlayer", null);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Pedestrian")) {
            other.GetComponent<PedestrianAI>().CarReact("exitPlayer", null);
        }
    }
}
