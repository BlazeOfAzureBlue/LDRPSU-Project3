using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    public AudioSource dirtSteps;
    public AudioSource churchSteps;


    private Rigidbody rigidbody;
    private Vector3 inputDirection;
    private bool isGrounded;
    public Camera camera;
    public float MoveSpeed = 10f;
    public float JumpStrength = 10f;
    public float gravityMultiplier = 2.5f;
    public float groundCheckDistance = 1.1f;
    private bool fastasfuck = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        inputDirection = camera.transform.right * x + camera.transform.forward * z;
        inputDirection = new Vector3(inputDirection.x, 0f, inputDirection.z);

        if (inputDirection.sqrMagnitude > 1f)
        {
            inputDirection.Normalize();
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, 0f, rigidbody.linearVelocity.z);
            rigidbody.AddForce(Vector3.up * JumpStrength, ForceMode.Impulse);
        }

        if(rigidbody.linearVelocity.y < 0f && !isGrounded)
        {
            rigidbody.linearVelocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            fastasfuck = true;
        }
        else
        {
            fastasfuck = false;
        }
    }

    private void FixedUpdate()
    {
        if(fastasfuck)
        {
            MoveSpeed = 15f;
        }
        else
        {
            MoveSpeed = 10f;
        }
        Vector3 horizontalVelocity = inputDirection * MoveSpeed;

        Vector3 newVelocity = new Vector3(horizontalVelocity.x, rigidbody.linearVelocity.y, horizontalVelocity.z);
        rigidbody.linearVelocity = newVelocity;
      
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dirt") && isGrounded)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                dirtSteps.enabled = true;
            }
            else
            {
                dirtSteps.enabled = false;
            }
        }
        else if(collision.gameObject.CompareTag("Church") && MoveSpeed > 0  && isGrounded)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                churchSteps.enabled = true;
            }
            else
            {
                churchSteps.enabled = false;
            }
        }
    }
}
