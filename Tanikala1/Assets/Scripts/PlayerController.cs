using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public GameObject footstep;
    public Animator animator;

    private Vector3 lastValidPosition;

    // UI elements for interaction with NPCs
    public GameObject mainPanel;
    public GameObject npcPanel;
    public Button closeButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        footstep.SetActive(false);
        lastValidPosition = transform.position;

        // Initialize the UI elements
        if (mainPanel == null || npcPanel == null || closeButton == null)
        {
            Debug.LogError("PlayerController: Panels or buttons are not assigned.");
            return;
        }

        closeButton.onClick.AddListener(CloseNPCPanel);
        npcPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position + Vector3.up; // Simplified cast position calculation
        if (Physics.Raycast(castPos, Vector3.down, out hit, Mathf.Infinity, terrainLayer))
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
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Debug log for collision detection

        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Collided with NPC");
            ShowNPCPanel();
        }
        else if (IsObstacle(collision.gameObject))
        {
            rb.velocity = Vector3.zero;
            transform.position = lastValidPosition;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (IsObstacle(collision.gameObject))
        {
            rb.velocity = Vector3.zero;
            transform.position = lastValidPosition;
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

    // Method to show the NPC interaction panel
    private void ShowNPCPanel()
    {
        npcPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    // Method to close the NPC interaction panel and return to the main panel
    private void CloseNPCPanel()
    {
        npcPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}










