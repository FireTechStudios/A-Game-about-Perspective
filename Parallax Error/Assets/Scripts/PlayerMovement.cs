using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	bool InAir;
	public float forwardForce = 20f;
	public float sidewaysForce = 20f;
    public bool constrainedControls = true;
    public GameObject cam3d;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1, 10)]
    public float jumpVelocity;
    public float distToGround;
    public bool isGrounded = false;
    public bool isMoving = false;
    [Range(0, 100)]
    public float maxSpeed;
    public float velocity;
    public GameObject camera3d;
    public Vector3 cameraFacing;
    public Vector3 cameraRight;
    public GameObject player;
    public float y;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = this.gameObject;
        Cursor.visible = false;
        rb.useGravity = true;
    }

public void Update()
    {
        //Rigidbody constraints
        if (ChangeCamera.isTransitioning)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
        }
        else if (constrainedControls)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (cam3d.activeInHierarchy == false)
        {
            constrainedControls = true;
        }
        else
            constrainedControls = false;

        if (Input.GetKeyDown("space"))
        {
            if (isGrounded == true && isMoving)
            {
                rb.velocity = new Vector3(rb.velocity.x , jumpVelocity, rb.velocity.z);
            }
            if (isGrounded == true && !isMoving)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpVelocity/1.15f, rb.velocity.z);
            }
        }



        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1.01f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void FixedUpdate ()
	{
        GroundCheck();
        //Check for movement (Xclude jumping)
        if (constrainedControls == true)
        {
            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                isMoving = true;
            }
            else
                isMoving = false;
        }
        else if (constrainedControls == false)
        {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                isMoving = true;
            }
            else
                isMoving = false;
        }

        cameraFacing = camera3d.transform.forward;
        cameraRight = camera3d.transform.right;

        if (constrainedControls)
        {
            if (Input.GetKey("a"))
            {
                rb.velocity = new Vector3(player.transform.right.x * velocity, rb.velocity.y, player.transform.right.z * velocity);
                //rb.AddForce(player.transform.right.x * velocity * Time.deltaTime, 0.0f, 0.0f, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                rb.velocity = new Vector3(-player.transform.right.x * velocity, rb.velocity.y, -player.transform.right.z * velocity);
                //rb.AddForce(-player.transform.right.x * velocity * Time.deltaTime, 0.0f, 0.0f, ForceMode.VelocityChange);
            }
        }
        else
        {
            if (Input.GetKey("w"))
            {
                rb.velocity = new Vector3(cameraFacing.x * velocity, rb.velocity.y, cameraFacing.z * velocity);
                //rb.AddForce(cameraFacing.x * velocity * Time.deltaTime, 0.0f, cameraFacing.z, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rb.velocity = new Vector3(-cameraRight.x * velocity, rb.velocity.y, -cameraRight.z * velocity);
                //rb.AddForce(-cameraRight.x * velocity * Time.deltaTime, 0.0f, -cameraRight.z, ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                rb.velocity = new Vector3(-cameraFacing.x * velocity, rb.velocity.y, -cameraFacing.z * velocity);
                //rb.AddForce(-cameraFacing.x * velocity * Time.deltaTime, 0.0f, -cameraFacing.z, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                rb.velocity = new Vector3(cameraRight.x * velocity, rb.velocity.y, cameraRight.z * velocity);
                //rb.AddForce(cameraRight.x * velocity * Time.deltaTime, 0.0f, cameraRight.z, ForceMode.VelocityChange);
            }
        }

        if(!Input.anyKeyDown && isGrounded && !isMoving)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
        }

        if (!Input.anyKeyDown && !isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
        }


        if (rb.velocity.sqrMagnitude > maxSpeed)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rb.velocity *= 0.985f;
        }

    }
}
