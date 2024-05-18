using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    public Rigidbody rigidbody;
    public float moveSpeed;

    public Vector2 moveInput;
    
    public LayerMask layerMask;
    public Transform groundPoint;
    public bool isGrounded;

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
}
