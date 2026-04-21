using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float strafeSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    public bool onGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Constant Forward Movement
        // Move the player forward automatically every frame
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // 2. Horizontal Movement (Left/Right)
        // Using GetAxis for smooth horizontal transitions
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 strafeMove = new Vector3(horizontalInput * strafeSpeed * Time.deltaTime, 0, 0);
        transform.Translate(strafeMove);

        // 3. Jump Logic
        // Check if player is on ground using a Raycast
        onGround = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround) 
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
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
