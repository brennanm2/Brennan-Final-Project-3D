using UnityEngine;

public class Jumping : MonoBehaviour {
    public float jumpForce = 10f;
    public bool isGrounded;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
    }

    void Jump() {
        // Apply upward velocity or force
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false; // Prevent jumping mid-air
    }

    // Basic ground detection using collisions
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
