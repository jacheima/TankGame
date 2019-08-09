using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatriciaAIController : AIController
{
    void Update()
    {
        switch (currentState)
        {
            case AI_STATES.Chase:
                ChaseAmbush();

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
                Flee();
                if (data.health > data.health / 2)
                {
                    ChangeState(AI_STATES.Flee);

                }

                if (data.health > (data.health / 2) + 2)
                {
                    ChangeState(AI_STATES.Chase);
                }

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

                if (Time.time >= scatterTime + scatterMin)
                {
                    ChangeState(AI_STATES.Chase);
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

