using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMover : MonoBehaviour
{
    public PawnData data;

    void Start()
    {
        data = GetComponent<PawnData>();
    }
    //This method move the pawn in the direction passed into it from the Input Controller
    public void Move(Vector3 directionToMove)
    {
        //move meters per second in the direction
        data.cc.Move(directionToMove * data.forwardSpeed * Time.deltaTime);
    }

    //This method rotates the pawn in the direction passes to it from the input controller
    public void Rotate(float direction)
    {
        data.tf.Rotate(new Vector3(0f, direction * data.rotateSpeed * Time.deltaTime, 0f));
    }

}
