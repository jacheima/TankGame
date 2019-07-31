using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnData : MonoBehaviour
{
    [Header("Components")]
    public PawnMover mover;
    public CharacterController cc;
    public MapGenerator map;
    public AIController aic;
    public BulletMover bm;

    public GameObject scatterWaypoint;
    public GameObject bullet;
    public GameObject bulletSpawn;
    
    public Transform tf;

    public float forwardSpeed = 10;
    public float rotateSpeed = 10;
    public float bulletCoolDown = 2f;
    public float shootTime = 0f;


    public GameManager gm;
    void Start()
    {
        mover = GetComponent<PawnMover>();
        cc = GetComponent<CharacterController>();
        tf = GetComponent<Transform>();
    }
}
