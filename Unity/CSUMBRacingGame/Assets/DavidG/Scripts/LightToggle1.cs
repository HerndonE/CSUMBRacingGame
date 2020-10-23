using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle1 : MonoBehaviour
{
    Light headlights;

    // Start is called before the first frame update
    void Start()
    {
        headlights = GetComponent<Light> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            headlights.enabled = !headlights.enabled;
        }
    }
}
