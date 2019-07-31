using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PawnData data;

    public GameObject[] enemies;
    public GameObject enemyParent;

    public void SpawnEnemy(int shipNumber)
    {
        //Get a random way point
        int randRoom = Random.Range(0, data.map.mapList.Count);

        Room randomRoom = data.map.mapList[randRoom].GetComponent<Room>();

        int randWayPoint = Random.Range(0, randomRoom.waypoints.Length);

        Debug.Log(shipNumber);

        switch (shipNumber)
        {
            case 0:
                //Blake

                if (!data.gm.Enemies.Contains(enemies[0]))
                {
                    //Instantiate Blake at the random waypoint
                    GameObject blake = Instantiate(enemies[0], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    blake.transform.parent = enemyParent.transform;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        blake.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);
                        

                    }

                    //sets the current point point index
                    blake.GetComponent<BlakeAIController>().currentPatrolPoint =
                        blake.GetComponent<BlakeAIController>().patrolPoints[0];

                    data.gm.Enemies.Add(enemies[0]); 
                }

                break;
            case 1:
                //Isaac

                if (!data.gm.Enemies.Contains(enemies[1]))
                {

                    //Instantiate Blake at the random waypoint
                    GameObject isaac = Instantiate(enemies[1], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    isaac.transform.parent = enemyParent.transform;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        //isaac.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);

                    }

                    //sets the current point point index

                    data.gm.Enemies.Add(enemies[1]); 
                }

                break;
            //Patricia
            case 2:
                if (!data.gm.Enemies.Contains(enemies[2]))
                {
                    //Instantiate Blake at the random waypoint
                    GameObject patricia = Instantiate(enemies[2], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    patricia.transform.parent = enemyParent.transform;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        //patricia.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);

                    }

                    //sets the current point point index

                    data.gm.Enemies.Add(enemies[2]); 
                }

                break;
            //Chris
            case 3:
                if (!data.gm.Enemies.Contains(enemies[2]))
                {

                    //Instantiate Blake at the random waypoint
                    GameObject chris = Instantiate(enemies[3], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    chris.transform.parent = enemyParent.transform;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        //chris.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);

                    }

                    //sets the current point point index

                    data.gm.Enemies.Add(enemies[3]);
                }
                break;
        }
    }
}
