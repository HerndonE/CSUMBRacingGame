using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Player player;
    public RectTransform needle;
    public Text speedText;

    float needleRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        needleRotation = (player.currentSpeed / player.maxSpeed) * -270 + 135;
        needle.rotation = Quaternion.Euler(0, 0, needleRotation);

        speedText.text = player.currentSpeed.ToString("F2");
    }
}
