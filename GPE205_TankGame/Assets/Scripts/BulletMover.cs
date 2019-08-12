using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    

    private Rigidbody rb;

    public float gunSpeed = 3.0f;
    public float bulletDestroy = 5.0f;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * gunSpeed;
        Destroy(gameObject, bulletDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            Destroy(gameObject, bulletDestroy); 
            gm.AddDamange(other.gameObject, gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject, bulletDestroy);
        }

        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject, bulletDestroy);
        }
    }
}
