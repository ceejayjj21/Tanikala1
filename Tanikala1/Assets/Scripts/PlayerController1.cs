using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController1 : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float moveSpeed;

    public Vector2 moveInput;

    public LayerMask groundLayerMask;
    public LayerMask obstacleLayerMask;
    public Transform groundPoint;
    public bool isGrounded;
    private Vector3 moveDirection;
    public float checkGroundDistance;

    void Start()
    {
        // Ensure the rigidbody reference is assigned
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        moveDirection = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;

        // Check if the player is grounded
        RaycastHit groundHit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out groundHit, checkGroundDistance, groundLayerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Apply movement to the rigidbody, preserving the current vertical velocity
        rigidbody.velocity = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision);
    }

    void OnCollisionStay(Collision collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision collision)
    {
        // Check if the player collides with objects that have specific tags
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Tree"))
        {
            // Prevent player from moving vertically through the object by stopping vertical movement
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);

            // Move the player slightly away from the obstacle to prevent continuous collision
            Vector3 pushBack = transform.position - collision.contacts[0].point;
            pushBack.y = 0; // Ensure the player is not pushed upwards
            transform.position += pushBack.normalized * 0.1f;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Allow player to move freely once they stop colliding with the object
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Tree"))
        {
            isGrounded = false;
        }
    }
}


