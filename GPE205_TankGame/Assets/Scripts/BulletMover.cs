using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    

    private Rigidbody rb;

    public float gunSpeed = 3.0f;
    public float bulletDestroy = 5.0f;

    public GameManager gm;

    public PawnData playerData;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * gunSpeed;
        Destroy(gameObject, bulletDestroy);
    }

    public void SetPlayer(PawnData data)
    {
        playerData = data;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("PlayerData: " + playerData);
        Debug.Log("PlayerData Tag" + playerData.gameObject.tag);
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PawnData>().health--;

            if (other.gameObject.GetComponent<PawnData>().health <= 0)
            {
                //the the person hit is player 1

                if (other.gameObject.tag == "Player")
                {
                    gm.player1died = true;
                    gm.player1.SetActive(false);
                }
                //if the person hit is player 2
                else if (other.gameObject.tag == "Player2")
                {
                    gm.player2died = true;
                    gm.player2.SetActive(false);
                }
                //if the person hit is an AI
                else
                {
                    Destroy(other.gameObject);

                    if()
                }

               
            }
        }
    }
}
