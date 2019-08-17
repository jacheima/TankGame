<<<<<<< HEAD
﻿using System.Collections;
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
    public FieldOfView fov;

    public GameObject scatterWaypoint;
    public GameObject bullet;
    public GameObject bulletSpawn;
    
    public Transform tf;

    public float forwardSpeed = 10;
    public float rotateSpeed = 10;
    public float bulletCoolDown = 2f;
    public float shootTime = 0f;

    public bool seesPlayer = false;
    public bool scatter = false;

    public float health = 10;

    public Camera player1cam;
    public Camera player2cam;

    public GameObject player1;
    public GameObject player2;

    public InputController player1IC;
    public Player2IC player2IC;



    public GameManager gm;
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        mover = GetComponent<PawnMover>();
        cc = GetComponent<CharacterController>();
        tf = GetComponent<Transform>();
        
        

        if (gm.singlePlayer == true && gm.multiplayer == false)
        {
            player2.SetActive(false);
            player2IC.gameObject.SetActive(false);
            player2cam.gameObject.SetActive(false);

            player1cam.rect = new Rect(0f, 0f, 1f, 1f);
        }

        if (gm.singlePlayer == false && gm.multiplayer == true)
        {
            player2.SetActive(true);
            player2IC.gameObject.SetActive(true);
            player2cam.gameObject.SetActive(true);

            player1cam.rect = new Rect(0f, 0f, .5f, 1f);
        }
    }
}
=======
﻿using System.Collections;
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
    public FieldOfView fov;

    public GameObject scatterWaypoint;
    public GameObject bullet;
    public GameObject bulletSpawn;
    
    public Transform tf;

    public float forwardSpeed = 10;
    public float rotateSpeed = 10;
    public float bulletCoolDown = 2f;
    public float shootTime = 0f;

    public bool seesPlayer = false;
    public bool scatter = false;

    public float health = 10;


    public GameManager gm;

    void Awake()
    {

        


    }
    void Start()
    {
        gm = GameManager.instance;

        gm.player1Score = 0;
        gm.player2Score = 0;

        mover = GetComponent<PawnMover>();
        cc = GetComponent<CharacterController>();
        tf = GetComponent<Transform>();

        gm.GetStuff();

        if (gm.singlePlayer == true && gm.multiPlayer == false && gm.player2 != null)
        {
            gm.player2.SetActive(false);
            gm.player2Camera.enabled = false;
            gm.player2IC.enabled = false;

            gm.player1Camera.rect = new Rect(0f, 0f, 1f, 1f);
        }

        if (gm.singlePlayer == false && gm.multiPlayer == true && gm.player2 != null)
        {
            gm.player2.SetActive(true);
            gm.player2Camera.enabled = true;
            gm.player2IC.enabled = true;

            gm.player1Camera.rect = new Rect(0f, 0f, .5f, 1f);
        }
    }

}
>>>>>>> master
