using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public PawnData data;
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask obstacleMask;
    public LayerMask objectMask;
    public List<Transform> visibleTargets = new List<Transform>();

    public bool seesEnemy = false;

    public Transform currentTarget;

    public Transform lastSighting;
    public GameObject enemyPosition;


    void Start()
    {

    }

    void Update()
    {
        CheckIfVisible();
    }


    void CheckIfVisible()
    {
        visibleTargets.Clear();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, viewRadius, objectMask);

        
        //for each item in hitColliders
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Transform target = hitColliders[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //check to see if it is the player
            if (hitColliders[i].gameObject.tag == "Player")
            {
                //check to see if the player is in the view angle
                if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
                {
                    //if so, check to see how far away they are
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    //raycast to the player to see if there are any obstacles
                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                    {
                        //if they are 
                        if (Vector3.Distance(transform.position, target.position) <= viewRadius)
                        {
                           data.seesPlayer = true;
                        }
                        else
                        {
                            data.seesPlayer = false;
                        }

                    }
                    else
                    {
                        data.seesPlayer = false;
                    }
                }
                else
                {
                    data.seesPlayer = false;
                }
            }
        }


    }




    public Vector3 AngleToTarget(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
