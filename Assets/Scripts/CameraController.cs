using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float rotationHorizontalModifier = 1;
	public float rotationVerticalModifier = 3;
	public Vector3 relativePosition = new Vector3(0f, 0f, -10f);
	public float horizontalRotation = 15;
	public float verticalRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target == null)
			return;

		horizontalRotation += Input.GetAxis("Mouse Y") * rotationHorizontalModifier;
		horizontalRotation = Mathf.Clamp(horizontalRotation, 0, 45);
		verticalRotation += Input.GetAxis("Mouse X")* rotationVerticalModifier;
		verticalRotation %= 360;

		transform.position = target.position + relativePosition;
		transform.RotateAround(target.position, Vector3.right, horizontalRotation);
		transform.RotateAround(target.position, Vector3.up, verticalRotation);
		transform.LookAt(target);
	}
}
