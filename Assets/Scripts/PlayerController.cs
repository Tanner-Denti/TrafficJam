using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5;

    private float horizontalInput;
    private float fowardInput;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");

        // Had to swap the the first parameters because the car asset isn't oriented properly
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed * fowardInput);
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * horizontalInput);
        
        

    }
}
