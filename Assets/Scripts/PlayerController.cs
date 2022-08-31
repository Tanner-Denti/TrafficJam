using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;

    private float speed = 10;
    private float impulseStrength = 2000;

    private float leftBound = -7.4f;
    private float rightBound = 10.2f;
    private float fowardBound = 5.0f;
    private float backwardBound = 21.0f;

    private bool canMoveRight = true;
    private bool canMoveLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        reactivateMovement();
    }

    // Move around with WASD
    void MovePlayer()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A) && canMoveLeft)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);  
        }

    }

    // Restrict the player from moving too far foward, back, or side to side. Bounce the player off of side walls.
    void ConstrainPlayerPosition()
    {

        if (transform.position.x < fowardBound)
        {
            transform.position = new Vector3(fowardBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > backwardBound)
        {
            transform.position = new Vector3(backwardBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z < leftBound)
        {
            canMoveLeft = false; // If we don't turn off movement in this direction, and the player holds this key down, we get visual jitter.
            transform.position = new Vector3(transform.position.x, transform.position.y, leftBound);
            playerRb.AddForce(new Vector3(0, 0, 1) * impulseStrength * Time.deltaTime, ForceMode.Impulse);
        }
        if (transform.position.z > rightBound)
        {
            canMoveRight = false; // If we don't turn off movement in this direction, and the player holds this key down, we get visual jitter.
            transform.position = new Vector3(transform.position.x, transform.position.y, rightBound);
            playerRb.AddForce(new Vector3(0, 0, -1) * impulseStrength * Time.deltaTime, ForceMode.Impulse);
        }

    }

    // Turn player movement back on after they have been "bounced" off of side walls. 
    void reactivateMovement()
    {
        if (transform.position.z >= -6.0 && transform.position.z <= 8.8f)
        {
            playerRb.velocity = new Vector3(0, 0, 0); // Stops the applied force, which can be inconsistent. Will be stopped on the z axis at -6 or 8.8.
            canMoveLeft = true;
            canMoveRight = true;
        }
        
    }

}
