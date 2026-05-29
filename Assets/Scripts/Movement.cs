using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float jumpForce = 5f;
    public Vector3 spawnPosition;
    public Rigidbody rb;
    public bool onGround;
    public Animator anim;

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
            anim.Play("slide");
        }
    if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("slide");
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Sliding", true);
        }
        else
        {
             anim.SetBool("Sliding", false);
    }

    if(Input.GetKeyDown(KeyCode.Space))
    {
        anim.SetBool("Jumping", true);
    }

    }





void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            
        }
        if (other.gameObject.tag == "New")
        {
            Debug.Log ("You have reached the Next Level, Good luck!)");
            
        }

    }
      
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "New")
        {
           forwardSpeed = 88;
        }
        if (other.gameObject.tag == "New Level 2")
        {
           forwardSpeed = 75;
        }
    }
        


void TaskOnClick()
{
    Debug.Log ("You have clicked the button!");
}
    }





