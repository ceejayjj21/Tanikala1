using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController1 : MonoBehaviour
{

    public Rigidbody rigidbody;
    public float moveSpeed;

    public Vector2 moveInput;
    
    public LayerMask layerMask;
    public Transform groundPoint;
    public bool isGrounded;
    private Vector3 moveDirection;
    public float checkGroundPoint;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rigidbody.velocity = new Vector3(moveInput.x * moveSpeed, rigidbody.velocity.y,moveInput.y * moveSpeed);

        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, checkGroundPoint, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with objects that have specific tags
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Car")
            || collision.gameObject.CompareTag("Tree"))
        {
            // Prevent player from moving through the object by setting the move direction to zero
            moveDirection = Vector3.zero;
            // Alternatively, you can apply a force in the opposite direction to simulate a bounce
            // rb.AddForce(-moveDirection * moveSpeed, ForceMode.Impulse);
        }
    }
}
