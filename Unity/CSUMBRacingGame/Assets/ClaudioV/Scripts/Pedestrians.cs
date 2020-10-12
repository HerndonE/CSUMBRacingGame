using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{
    public Transform waypoints;

    [Header("Pedestrians")]
    public Pedestrian santaPedestrian;
    public Pedestrian copPedestrian;
    public Pedestrian doctorPedestrian;
    public Pedestrian knightPedestrian;
    public Pedestrian nursePedestrian;
    public Pedestrian patientPedestrian;
    public Pedestrian robberPedestrian;
    public Pedestrian villagerPedestrian;
    public Pedestrian zombiePedestrian;

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

                pedestrians[i].Add(Instantiate(RandomPedestrian(), new Vector3(waypointPos.x, 0.375f, waypointPos.z), Quaternion.identity, transform));
                pedestrians[i][j].SpawnPedestrian(currWPLoop, j);
            }
        }
    }

    Pedestrian RandomPedestrian() {
        int random = Random.Range(0, 9);

        // Ignore use Switch Expression Message, Doesn't work with Unity
        switch(random) {
            case 0:
                return santaPedestrian;
            case 1:
                return copPedestrian;
            case 2:
                return doctorPedestrian;
            case 3:
                return knightPedestrian;
            case 4:
                return nursePedestrian;
            case 5:
                return patientPedestrian;
            case 6:
                return robberPedestrian;
            case 7:
                return villagerPedestrian;
            case 8:
                return zombiePedestrian;
            default:
                return santaPedestrian;
        }
    }
}
