using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    
    public GameObject lightObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Speed of light transform changes to speed up night phase
        //X coordinate 170 = start of night
        //X coordinate 10 = end of night
        //if(lightObject.transform.position.x >= 170 || lightObject.transform.position.x <= 0)
        //{
        //    Debug.Log("we are in the statement now");
        //}
            lightObject.transform.Rotate(.025f, .025f, .025f, Space.Self);
    }
}
