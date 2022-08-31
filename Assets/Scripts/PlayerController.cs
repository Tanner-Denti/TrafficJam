using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private float speed = 10;

    private float horizontalInput;
    private float fowardInput;

    private float leftBound;
    private float rightBound;
    private float fowardBound;
    private float backwardBound;

    private float impulseStrength = 250;
    public float buffer = 0.0f;


    private Collider rightWall;
    private Collider leftWall;
    private Collider playerCollider;

    public bool onCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerCollider = GetComponent<Collider>();
        //rightWall = GameObject.Find("RightWallCollider").GetComponent<Collider>();
        //leftWall = GameObject.Find("LeftWallCollider").GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        if (!onCollision)
        {
            // Gets horizontal and vertical 
            horizontalInput = Input.GetAxis("Horizontal");
            fowardInput = Input.GetAxis("Vertical");

            // Had to swap the the first parameters because the car asset isn't oriented properly
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed * fowardInput);
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * horizontalInput);
        }
    }

    void ConstrainPlayerPosition()
    {
        leftBound = -7.5f;


        if (transform.position.z < leftBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, leftBound);
            // playerRb.AddForce(new Vector3(0, 0, 1) * impulseStrength * Time.deltaTime, ForceMode.Impulse);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.CompareTag("leftWall"))
    //    {
    //        onCollision = true;
    //        playerRb.AddForce(new Vector3(0, 0, 1) * impulseStrength * Time.deltaTime, ForceMode.Impulse);
    //    }

    //    if (collision.gameObject.CompareTag("rightWall"))
    //    {
    //        onCollision = true;
    //        playerRb.AddForce(new Vector3(0, 0, -1) * impulseStrength * Time.deltaTime, ForceMode.Impulse);
    //    }
        
    //}


    //private void OnCollisionExit(Collision collision)
    //{ 
    //    if (collision.gameObject.CompareTag("leftWall") || collision.gameObject.CompareTag("rightWall"))
    //    {
    //        while (buffer <= 100000.0f)
    //        {
    //            buffer += Time.deltaTime;
    //        }
    //        if (buffer >= 100000.0f)
    //        {
    //            buffer = 0.0f;
    //            onCollision = false;
    //            Destroy(gameObject);
    //        } 
    //    }
        
    //}

}
