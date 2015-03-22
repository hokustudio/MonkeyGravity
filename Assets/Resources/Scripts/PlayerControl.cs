using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetTouch ();
	}

	private void GetTouch() {
		if (Input.GetKey (KeyCode.UpArrow)) {
			PlayerPhysic.myInstance.ThrustForce ();

		} else {
			PlayerPhysic.myInstance.ThrustForceStop ();
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerPhysic.myInstance.RotationLeft ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			PlayerPhysic.myInstance.RotationRight ();
		}
	}
}
