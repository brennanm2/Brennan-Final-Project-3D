using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    // By making this private, it will not appear in the editor
    private Rigidbody rb;

    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public float walkSpeed;
    public float sprintSpeed;
    
    private float currentSpeed;


    public bool onGround;
    public int playerLives;

    public Vector3 spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Automatically looks for a Rigidbody component on the current GameObject
        rb = GetComponent<Rigidbody>();

        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ------- Movement -------

        // Creates one vector where X is the input from A and D, and Z is the input from X and Y
        Vector3 movementInput = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");

       // Debug.Log("Original value: " + movementInput);

        movementInput = Vector3.Normalize(movementInput);

       // Debug.Log("Normalized value: " +movementInput);

        // Start from current location, and then slightly adjusts the position by adding on the inputs scaled by speed and adjusted for framerate
        Vector3 targetPosition = rb.position + movementInput * moveSpeed * Time.deltaTime;

        // Moves the rigidbody to its target position
        rb.MovePosition(targetPosition);

         if (Input.GetKey(KeyCode.LeftShift))
         {
          moveSpeed = sprintSpeed;
         }
       else 
       {
        moveSpeed = walkSpeed;
       }
       
        

        // ------- Rotation -------

        // Clockwise rotations
        if (Input.GetKey(KeyCode.E))
        {
            
            // Start from the current rotation, converting it to a Vector
            Vector3 currentRotation = rb.rotation.eulerAngles;

            // Add to the y-coordinate of the angle to rotate clockwise
            Vector3 targetRotation = currentRotation + Vector3.up * turnSpeed * Time.deltaTime;

            // Need to change the target rotation to a quaternion before passing it to rigidbody
            rb.MoveRotation(Quaternion.Euler(targetRotation));
        }
        
        if(Input.GetKey(KeyCode.Q))
       {
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
       }
        // ------- Jumping -------

        // Add a force impulse to the player that pushes them upwards
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround) 
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        // --------- Respawning ---------
    if (transform.position.y < 0)

    {
        rb.position = spawnPosition;


    }

    // Player Lives 


 

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            
        }
         if (collision.gameObject.tag == "Hazard")
        {
             rb.position = spawnPosition;
        }
         if (collision.gameObject.tag == "Spring")
        {
             jumpForce = 24;
        }
        if (collision.gameObject.tag == "RESET")
        {
             jumpForce = 9;
        }
        if (collision.gameObject.tag == "end")
 {
    Debug.Log("This is the end, QUICK, SPRINT TO THE FLAG IN UNDER 13 SECONDS; THIS IS ICE SO TREADY LIGHTLY");
}
if (collision.gameObject.tag == "Win")
 {
    Debug.Log("CONGRATS YOU WIN!!!");
}
if (collision.gameObject.tag == "Hint")
 {
    Debug.Log("HINT: To pass the next level, collect the golden orb for special powers");
}
    
    
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }


     void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
        
     
    }
 
 }
 
