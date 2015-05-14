using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float relativeX = 0f;
	public float relativeY = 5f;
	public float relativeZ = -10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target == null)
			return;
		transform.position = target.position + new Vector3(relativeX, relativeY, relativeZ);
		transform.LookAt(target);
	}
}
