using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string nextLevel;
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.F1))
			Application.LoadLevel(nextLevel);
	}
}
