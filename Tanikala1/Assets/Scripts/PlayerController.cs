using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public GameObject footstep;
    public Animator animator;

    private Vector3 lastValidPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        footstep.SetActive(false);
        lastValidPosition = transform.position;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position + Vector3.up; // Simplified cast position calculation
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + groundDist, transform.position.z);
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);

        Vector3 movDir = new Vector3(x, 0, y) * speed;

        rb.velocity = movDir;

        if (x != 0 || y != 0)
        {
            footstep.SetActive(true);
        }
        else
        {
            footstep.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsObstacle(collision.gameObject))
        {
            // Do nothing on collision enter, handle it in FixedUpdate
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (IsObstacle(collision.gameObject))
        {
            // Do nothing on collision stay, handle it in FixedUpdate
        }
    }

    private void FixedUpdate()
    {
        // Check if the player is currently colliding with any obstacles
        bool isColliding = IsCollidingWithObstacles();

        if (isColliding)
        {
            // If colliding, reset the player's position to the last valid position
            rb.velocity = Vector3.zero;
            transform.position = lastValidPosition;
        }
        else
        {
            // If not colliding, update the last valid position
            lastValidPosition = transform.position;
        }
    }

    private bool IsObstacle(GameObject gameObject)
    {
        // Check if the collided object has any of the specified tags
        return gameObject.CompareTag("Building") || gameObject.CompareTag("Car") || gameObject.CompareTag("Tree") || gameObject.CompareTag("Road");
    }

    private bool IsCollidingWithObstacles()
    {
        // Check if the player is currently colliding with any obstacles
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f); // Adjust the radius if needed
        foreach (Collider collider in colliders)
        {
            if (IsObstacle(collider.gameObject))
            {
                return true;
            }
        }
        return false;
    }
}






