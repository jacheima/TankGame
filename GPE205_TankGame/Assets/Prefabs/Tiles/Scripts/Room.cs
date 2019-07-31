using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{ 
    public GameObject wallNorth;
    public GameObject wallSouth;
    public GameObject wallEast;
    public GameObject wallWest;

    public Transform[] waypoints;
    public Transform powerUpSpawan;

    public int PowerUpSpawnIndex;
    public int EnemySpawnIndex;


    void Start()
    {
        PowerUpSpawnIndex = Random.Range(0, waypoints.Length);
        EnemySpawnIndex = Random.Range(0, waypoints.Length);

        if (PowerUpSpawnIndex == EnemySpawnIndex)
        {
            EnemySpawnIndex = Random.Range(0, waypoints.Length);
        }
    }
}
