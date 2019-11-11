using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private bool isOnGround;
    public float speed = 2f;
    public float jumpForce = 50f;
    private float gravityModifier = 5f;

    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Handle colliding on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // Handle colliding with enemy
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player got the food");
        }
    }

    // Move the player left or right, or jump based on keyboard input
    private void MovePlayer()
    {
        // Get the player inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Move the player left / right
        playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime, ForceMode.Impulse);
        playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime, ForceMode.Impulse);

        // Jump the player
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

}
