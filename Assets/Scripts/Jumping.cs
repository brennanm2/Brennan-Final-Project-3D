using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 8f;
    public LayerMask groundLayer;
    public Transform groundCheckTransform;
    public float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private bool onGround;
    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. ALWAYS capture input in Update so you never miss a keypress
        if (Input.GetButtonDown("Jump") && onGround)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        // 2. Perform ground check inside FixedUpdate for accurate physics synchronization
        CheckGroundStatus();

        // 3. Apply the jump force inside FixedUpdate
        if (jumpRequested)
        {
            // Reset vertical velocity first to ensure consistent jump height every time
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            
            // Apply upward impulse force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            jumpRequested = false;
        }
    }

    void CheckGroundStatus()
    {
        // Creates a small invisible sphere at the player's feet to check for the Ground layer
        onGround = Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, groundLayer);
    }

    // Visualizes the ground check sphere in the Unity Editor scene view
    void OnDrawGizmosSelected()
    {
        if (groundCheckTransform != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            
        }
}

}

