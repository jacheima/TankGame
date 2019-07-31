using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //This is the input controller, it gets input from the player controller and send the info over to the script that controls movement

    //Reference to the Pawn Data script that holds all the variables related to the pawns
    public PawnData data;

    void Update()
    {
        //Tell the mover I am not moving
        Vector3 directionToMove = Vector3.zero;

        //if the player presses W
        if (Input.GetKey(KeyCode.W))
        {
            //then tell the mover to move in a forward direction
            directionToMove += data.tf.forward;
        }

        //if the player presses S
        if (Input.GetKey(KeyCode.S))
        {
            //then tell the mover to move in a backward direction
            directionToMove += -data.tf.forward;
        }

        //if the player press D
        if (Input.GetKey(KeyCode.D))
        {
            //then tell the mover to rotate to the right
            data.mover.Rotate(data.rotateSpeed * Time.deltaTime);
        }

        //if the player presses A
        if (Input.GetKey(KeyCode.A))
        {
            //then tell the mover to rotate to the left
            data.mover.Rotate(-data.rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > data.shootTime + data.bulletCoolDown)
            {
                GameObject bullet = Instantiate(data.bullet, data.bulletSpawn.transform.position, data.bulletSpawn.transform.rotation);
                data.shootTime = Time.deltaTime;
            }
        }

        data.mover.Move(directionToMove);

    }
}
