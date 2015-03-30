using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

	public GameObject bgMusic;
	
	void Start ()
	{
		bgMusic.GetComponent<AudioSource> ().Play ();
	}

	void Update ()
	{
		GetTouch ();
	}

	private void GetTouch ()
	{
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
