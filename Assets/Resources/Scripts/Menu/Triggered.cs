using UnityEngine;
using System.Collections;

public class Triggered : MonoBehaviour {
	private const string KEY_BACKGROUND1 ="BG0";
	private const string KEY_BACKGROUND2 ="BG1";
	void OnTriggerEnter2D(Collider2D other){
		switch (other.name) {
		case KEY_BACKGROUND1:
		case KEY_BACKGROUND2:
			other.GetComponent<BackgroundScrolling> ().ResetScrolling ();
			break;
		}
	}
}

