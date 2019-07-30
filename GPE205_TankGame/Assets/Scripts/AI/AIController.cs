using System.Collections;
using System.Collections.Generic;
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

    //enums
    public enum AI_STATES
    {
        
    }


}
