using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float jumpForce = 5f;
    public Vector3 targetPosition = new Vector3(30f, 2.6f, -125.5f);

    public Rigidbody rb;
    public Animator anim;
    public bool onGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
       //From google
        // 1. Constant Forward Movement
        // Move the player forward automatically every frame
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

    if(Input.GetKeyDown(KeyCode.Space))
    {
         if (onGround) 
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
    }

        if(Input.GetKeyDown(KeyCode.A))
       {
        transform.position = transform.position - new Vector3(17, 0, 0);
       }

        if(Input.GetKeyDown(KeyCode.D))
       {
        transform.position = transform.position + new Vector3(17, 0, 0);
       }

       if(Input.GetKeyDown(KeyCode.S))
       {
            anim.SetBool("isSliding", true);
       }
       else
       {
            anim.SetBool("isSliding", false);
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
