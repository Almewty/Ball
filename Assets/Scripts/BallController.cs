using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	public float sleepVelocity;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(horizontal, 0f, vertical);

		if (horizontal == 0 && vertical == 0 && rb.angularVelocity.sqrMagnitude < sleepVelocity)
			rb.angularVelocity = Vector3.zero;
		else
			rb.AddForce(movement * speed);

		if (Input.GetButton("Jump"))
		{
			rb.AddForce(0f, 100f, 0f);
		}
	}
}
