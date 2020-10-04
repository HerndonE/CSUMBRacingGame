using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCollider : MonoBehaviour
{
    PedestrianAI parentScript;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = transform.GetComponentInParent<PedestrianAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            parentScript.CarReact("enterPedestrian", other.transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            parentScript.CarReact("exitPedestrian", other.transform);
        }
    }
}
