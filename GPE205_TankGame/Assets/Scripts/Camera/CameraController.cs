using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //reference to the pawn data script
    public PawnData data;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - data.tf.position;
    }

    void Update()
    {
        transform.position = data.tf.position + offset;
    }
}
