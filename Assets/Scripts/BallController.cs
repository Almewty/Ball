using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	public float sleepVelocity;
	public float jumpForce;

	private Rigidbody rb;
	private bool isGrounded;
	private new Camera camera;

	// Use this for initialization
	void Start () {
		isGrounded = false;
		rb = GetComponent<Rigidbody>();
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(horizontal, 0f, vertical);

		if (horizontal == 0 && vertical == 0 && 
		    rb.angularVelocity.sqrMagnitude < sleepVelocity && rb.velocity.sqrMagnitude < sleepVelocity &&
		    isGrounded)
		{
			rb.angularVelocity = Vector3.zero;
			rb.velocity = Vector3.zero;
		}
		else
		{
			var cameraForward = camera.transform.forward;
			cameraForward.y = 0;
			cameraForward = cameraForward.normalized;
			rb.AddForce(Quaternion.FromToRotation(Vector3.forward, cameraForward) * movement * speed);

		}
		if (Input.GetButton("Jump") && isGrounded)
		{
			rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			rb.AddForce(Vector3.up * jumpForce);
		}


	}

	void OnCollisionEnter(Collision collision)
	{
		//if (collision.gameObject.tag == "Floor")
			isGrounded = true;
	}
	
	void OnCollisionStay(Collision collision)
	{
		//if (collision.gameObject.tag == "Floor")
			isGrounded = true;
	}

	void OnCollisionExit(Collision collision)
	{
		//if (collision.gameObject.tag == "Floor")
			isGrounded = false;
	}
}
