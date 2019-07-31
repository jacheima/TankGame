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

    //int variables
    public int currentPatrolIndex = 0;

    //float variable
    public float stateStartTime;

    //AI_STATE variables
    public AI_STATES currentState;

    public bool scatter = false;

    public float scatterTime;
    public float scatterMin = 5f;
    public float scatterMax = 15f;

    //enums
    public enum AI_STATES
    {
        Chase, Scatter, Flee, Shoot, PowerUp
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
            GameObject bullet = Instantiate(data.bullet, data.bulletSpawn.transform.position, data.bulletSpawn.transform.rotation);
            data.shootTime = Time.time;
        }

          
        
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
