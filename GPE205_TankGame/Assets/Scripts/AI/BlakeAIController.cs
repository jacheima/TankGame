using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class BlakeAIController : AIController
{
    
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case AI_STATES.Chase:
                ChaseAggressive();

                if (Vector3.Distance(transform.position,
                        GameObject.FindGameObjectWithTag("Player").transform.position) < 2f)
                {
                    ChangeState(AI_STATES.Shoot);
                }
                break;
            case AI_STATES.Flee:
                break;
            case AI_STATES.PowerUp:
                break;
            case AI_STATES.Scatter:
                break;
            case AI_STATES.Shoot:
                Shoot();

                if (Vector3.Distance(transform.position,
                        GameObject.FindGameObjectWithTag("Player").transform.position) > 10f)
                {
                    ChangeState(AI_STATES.Chase);
                }
                break;
        }
    }
}
