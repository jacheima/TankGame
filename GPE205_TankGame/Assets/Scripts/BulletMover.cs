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
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PawnData>().health--;

            if (other.gameObject.GetComponent<PawnData>().health <= 0)
            {

                //if (other.gameObject == playerData.gameObject)
                //{
                //    if (playerData.gameObject.tag == "Player")
                //    {
                //        playerData.gm.player1died = true;
                //    }

                //    if (playerData.gameObject.tag == "Player2")
                //    {
                //        playerData.gm.player2died = true;
                //    }
                //}

                if (playerData.gameObject.tag == "Player")
                {
                    gm.player1Score++;
                }

                if (playerData.gameObject.tag == "Player2")
                {
                    gm.player2Score++;
                }

                Destroy(other.gameObject);

            }
        }
    }
}
