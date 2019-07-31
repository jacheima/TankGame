using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using ICanvasRaycastFilter = UnityEngine.ICanvasRaycastFilter;

public class BlakeAIController : AIController
{
    
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case AI_STATES.Chase:
                ChaseAggressive();

                if (data.seesPlayer == true)
                {
                    ChangeState(AI_STATES.Shoot);
                }

                if (Time.time >= scatterTime)
                {
                    ChangeState(AI_STATES.Scatter);
                }
                break;
            case AI_STATES.Flee:
                break;
            case AI_STATES.PowerUp:
                break;
            case AI_STATES.Scatter:
                Scatter();
                if (Time.time <= scatterTime && data.seesPlayer == false)
                {
                    ChangeState(AI_STATES.Chase);
                }
                Scatter();
                if (Time.time <= scatterTime && data.seesPlayer == false)
                {
                    ChangeState(AI_STATES.Shoot);
                }
                break;
            case AI_STATES.Shoot:
                Shoot();

                if (data.seesPlayer == false)
                {
                    if (data.scatter == true)
                    {
                        ChangeState(AI_STATES.Scatter);
                    }
                    else
                    {
                        ChangeState(AI_STATES.Chase);
                    }
                }

                if (Time.time >= scatterTime && data.seesPlayer == false)
                {
                    ChangeState(AI_STATES.Scatter);
                }
                break;
        }
    }
}
