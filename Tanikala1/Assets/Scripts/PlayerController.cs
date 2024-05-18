using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    public Animator animator;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPost = transform.position;

        castPost.y += 1;
        if (Physics.Raycast(castPost, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal",x);
        animator.SetFloat("Vertical", y);

        Vector3 movDir = new Vector3(x, 0, y);

        rb.velocity = movDir * speed;

        //if (x != 0 && x < 0)
        //{
        //    sr.flipX = true;
        //}
        //else if (x != 0 && x > 0)
        //{
        //    sr.flipX = false;
        //}

    }
}
