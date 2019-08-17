using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PawnData data;

    public GameObject[] enemies;
    public GameObject enemyParent;

    public GameObject scatter;

<<<<<<< HEAD
    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Player").GetComponent<PawnData>();
    }

=======
    public GameManager gm;

    void Awake()
    {
    }

    void Start()
    {
        gm = GameManager.instance;
    }
>>>>>>> master
    public void SpawnEnemy(int shipNumber)
    {
        //Get a random way point
        int randRoom = Random.Range(0, data.map.mapList.Count);

        Room randomRoom = data.map.mapList[randRoom].GetComponent<Room>();

        int randWayPoint = Random.Range(0, randomRoom.waypoints.Length);

        switch (shipNumber)
        {
            case 0:
                //Blake


                Debug.Log("Gm: " + gm);
                Debug.Log("Enemies in gm: " + gm.Enemies);
                Debug.Log("enmenies in spawer from first index: " + enemies[0]);

                if (!gm.Enemies.Contains(enemies[0]))
                {
                    //Instantiate Blake at the random waypoint
                    GameObject blake = Instantiate(enemies[0], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    blake.transform.parent = enemyParent.transform;

                    GameObject scatterWP = Instantiate(scatter, new Vector3(5f, .33f, 2f), Quaternion.identity);

                    blake.GetComponent<BlakeAIController>().scatterWaypoint = scatterWP;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        blake.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);
                        

                    }

                    //sets the current point point index
                    blake.GetComponent<BlakeAIController>().currentPatrolPoint =
                        blake.GetComponent<BlakeAIController>().patrolPoints[0];

                    gm.Enemies.Add(enemies[0]); 
                }

                break;
            case 1:
                //Isaac
                Debug.Log("Gm: " + GameManager.instance.gameObject);
                Debug.Log("Enemies in gm: " + GameManager.instance.Enemies);
                Debug.Log("enmenies in spawer from first index: " + enemies[1]);

                if (!gm.Enemies.Contains(enemies[1]))
                {

                    //Instantiate Blake at the random waypoint
                    GameObject isaac = Instantiate(enemies[1], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    isaac.transform.parent = enemyParent.transform;

                    GameObject scatterWP = Instantiate(scatter, new Vector3(12f, .33f, -5f), Quaternion.identity);

                    isaac.GetComponent<IsaacAIController>().scatterWaypoint = scatterWP;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        //isaac.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);

                    }

                    //sets the current point point index

                    gm.Enemies.Add(enemies[1]); 
                }

                break;
            //Patricia
            case 2:

                Debug.Log("Gm: " + gm);
                Debug.Log("Enemies in gm: " + gm.Enemies);
                Debug.Log("enmenies in spawer from first index: " + enemies[2]);
                if (!gm.Enemies.Contains(enemies[2]))
                {
                    //Instantiate Blake at the random waypoint
                    GameObject patricia = Instantiate(enemies[2], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    patricia.transform.parent = enemyParent.transform;

                    GameObject scatterWP = Instantiate(scatter, new Vector3(-2f, .33f, -5f), Quaternion.identity);

                    patricia.GetComponent<PatriciaAIController>().scatterWaypoint = scatterWP;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        //patricia.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);

                    }

                    //sets the current point point index

                    gm.Enemies.Add(enemies[2]); 
                }

                break;
            //Chris
            case 3:
                Debug.Log("Gm: " + gm);
                Debug.Log("Enemies in gm: " + gm.Enemies);
                Debug.Log("enmenies in spawer from first index: " + enemies[3]);
                if (!gm.Enemies.Contains(enemies[3]))
                {

                    //Instantiate Blake at the random waypoint
                    GameObject chris = Instantiate(enemies[3], randomRoom.waypoints[randWayPoint].position, Quaternion.identity);

                    //child the object
                    chris.transform.parent = enemyParent.transform;

                    GameObject scatterWP = Instantiate(scatter, new Vector3(5f, .33f, -12f), Quaternion.identity);

                    chris.GetComponent<ChrisAIController>().scatterWaypoint = scatterWP;

                    //for each waypoint in waypoints
                    for (int i = 0; i < randomRoom.waypoints.Length; i++)
                    {
                        //add the waypoints to the patrol list
                        //chris.GetComponent<BlakeAIController>().patrolPoints.Add(randomRoom.waypoints[i]);

                    }

                    //sets the current point point index

                    gm.Enemies.Add(enemies[3]);
                }
                break;
        }
    }
}
