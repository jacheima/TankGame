using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2IC : MonoBehaviour
{

    //This is the input controller, it gets input from the player controller and send the info over to the script that controls movement

    //Reference to the Pawn Data script that holds all the variables related to the pawns
    public PawnData data;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Tell the mover I am not moving
        Vector3 directionToMove = Vector3.zero;

        //if the player presses Up Arrow
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //then tell the mover to move in a forward direction
            directionToMove += data.tf.forward;
        }

        //if the player presses down arrow
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //then tell the mover to move in a backward direction
            directionToMove += -data.tf.forward;
        }

        //if the player press right arrow
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //then tell the mover to rotate to the right
            data.mover.Rotate(data.rotateSpeed * Time.deltaTime);
        }

        //if the player presses Left Arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //then tell the mover to rotate to the left
            data.mover.Rotate(-data.rotateSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Keypad0))
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
