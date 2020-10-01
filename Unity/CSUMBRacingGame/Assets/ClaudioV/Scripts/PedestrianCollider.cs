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

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            parentScript.SetFreeze(true);
        }
    }

    public void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            parentScript.SetFreeze(false);
        }
    }
}
