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
    public bool grounded = true;
    [Range(1, 10)]
    public float jumpVelocity;
    public float distToGround;
    public bool isGrounded;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

public void Update()
    {

        if (cam3d.activeInHierarchy == false)
        {
            constrainedControls = true;
        }
        else
            constrainedControls = false;

        if (Input.GetKeyDown("space"))
        {
            GroundCheck();
            if (isGrounded == true)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
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
        float distance = 1f;
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
        if (Input.GetKey("w"))  // If the player is pressing the "d" key
        {
            if (constrainedControls == false)
                // Add a force to the right
                rb.AddForce(-forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))  // If the player is pressing the "d" key
        {
            if (constrainedControls == false)
                // Add a force to the right
                rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))	// If the player is pressing the "a" key
		{
            if (constrainedControls == false)
                // Add a force to the right
                rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            else
            {
                rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

		if (Input.GetKey("d"))  // If the player is pressing the "d" key
		{
            if (constrainedControls == false)
                // Add a force to the left
                rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            else
            {
                rb.AddForce(-forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
		}






	}
}
