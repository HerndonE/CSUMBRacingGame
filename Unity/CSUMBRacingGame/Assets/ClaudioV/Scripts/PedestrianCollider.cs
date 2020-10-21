using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCollider : MonoBehaviour
{
    Pedestrian parentScript;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = transform.GetComponentInParent<Pedestrian>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && parentScript != null) {
            parentScript.CarReact("enterPedestrian", other.transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && parentScript != null) {
            parentScript.CarReact("exitPedestrian", other.transform);
        }
    }
}
