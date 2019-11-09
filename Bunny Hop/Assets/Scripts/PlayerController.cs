using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private BoxCollider groundBC;

    private bool isOnGround;
    private float speed = 10f;
    private float jumpForce = 10f;
    private float gravityModifier = 5f;
    private float xbound;
    private float zbound;

    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        groundBC = GameObject.Find("Ground").GetComponent<BoxCollider>();

        xbound = groundBC.size.x;
        zbound = groundBC.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Move the player left / right
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        // Jump the player
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        // Keep player in bounds
        if (transform.position.x > xbound)
        {
            transform.position = new Vector3(xbound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xbound)
        {
            transform.position = new Vector3(-xbound, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbound);
        }

        if (transform.position.z < -zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zbound);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Handle colliding on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // Handle colliding with food

        // Handle colliding with enemy
    }
}
