using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //component variables
    public PawnData data;

    //transform variables
    public List<Transform> patrolPoints;
    public Transform currentPatrolPoint;

    public GameObject scatterWaypoint;

    //int variables
    public int currentPatrolIndex = 0;

    //float variable
    public float stateStartTime;

    //AI_STATE variables
    public AI_STATES currentState;

    public bool scatter = false;

    public float scatterTime;
    public int scatterMin = 10;
    public int scatterMax = 60;

    //enums
    public enum AI_STATES
    {
        Chase, Scatter, Flee, Shoot
    }



    void Start()
    {
        StartCoroutine(ChooseScatterWaitTime());
    }

    public void ChaseAggressive()
    {
        //get the position of the player
        Transform playerPosition = GameObject.FindGameObjectWithTag("Aggressive").transform;

        //find the direction to the player
        Vector3 targetDirection = (playerPosition.position - transform.position).normalized;

        //move to the player
        Seek(targetDirection);
    }
    public void ChaseAmbush()
    {
        //find the position of the ambush point
        Transform ambushPosition = GameObject.FindGameObjectWithTag("Ambush").GetComponent<Transform>();

        //find the direction to the ambush point
        Vector3 targetDirection = (transform.position - ambushPosition.position).normalized;

        //Move to the ambush point
        Seek(targetDirection);
    }

    public void ChasePatrol()
    {

        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >
            data.fov.viewRadius)
        {
            Vector3 directionToPlayer = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
            Seek(directionToPlayer);
        }
        else
        {
            Vector3 directionToTarget = (currentPatrolPoint.position - transform.position).normalized;
            Seek(directionToTarget);

            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 5f)
            {

                if (currentPatrolIndex + 1 < patrolPoints.Count)
                {
                    currentPatrolIndex++;

                }
                else
                {
                    currentPatrolIndex = 0;

                }

                currentPatrolPoint = patrolPoints[currentPatrolIndex];
            }
        }
    }

    public void ChaseRandom()
    {
        int n = Random.Range(0, 2);

        switch (n)
        {
            case 0:
                ChaseAggressive();
                break;
            case 1:
                ChaseAmbush();
                break;
            case 2:
                ChasePatrol();
                break;
        }
    }

    public void Shoot()
    {
        data.mover.RotateTowards((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized);

        if (Time.time > data.shootTime + data.bulletCoolDown)
        {
            if (Vector3.Angle(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <
                data.fov.viewAngle / 2)
            {
                GameObject bullet = Instantiate(data.bullet, data.bulletSpawn.transform.position, data.bulletSpawn.transform.rotation);
                data.shootTime = Time.time;
            }
        }
        
    }

    public void Flee()
    {
        Scatter();
        data.health += (data.health / 4) * Time.deltaTime;
    }

    IEnumerator ChooseScatterWaitTime()
    {
        int n = Random.Range(scatterMin, scatterMax);
        scatterTime = n;

        yield return new WaitForSeconds(n);
    }

    public void Scatter()
    {
        Vector3 directionToTarget = (scatterWaypoint.transform.position - transform.position).normalized;
        Seek(directionToTarget);
    }

    public void Seek(Vector3 directionToMove)
    {
        data.mover.RotateTowards(directionToMove);
        data.mover.Move(directionToMove);
    }

    public void ChangeState(AI_STATES state)
    {
        stateStartTime = Time.time;
        currentState = state;
    }
}
