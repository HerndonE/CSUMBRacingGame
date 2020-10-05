using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{
    public Pedestrian pedestrianPF;
    public Transform waypoints;

    // List of All Pedestrians Divided by Waypoint Loops
    List<List<Pedestrian>> pedestrians;

    // Start is called before the first frame update
    void Start()
    {
        pedestrians = new List<List<Pedestrian>>();

        // Loop through All Waypoint Loops
        for (int i = 0; i < waypoints.childCount; i++) {
            Transform currWPLoop = waypoints.GetChild(i);
            pedestrians.Add(new List<Pedestrian>());

            // Loop through Each Waypoint in Loop, Spawn a Pedestrian at Each Waypoint
            for (int j = 0; j < currWPLoop.childCount; j++) {
                Vector3 waypointPos = currWPLoop.GetChild(j).position;

                pedestrians[i].Add(Instantiate(pedestrianPF, new Vector3(waypointPos.x, 0.375f, waypointPos.z), Quaternion.identity, transform));
                pedestrians[i][j].SpawnPedestrian(currWPLoop, j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
