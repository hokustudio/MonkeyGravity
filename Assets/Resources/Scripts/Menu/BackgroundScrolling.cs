using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour {
	private float scrollSpeed = -0.025f;
	public Transform anchorBG;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Scrolling();
	}

	private void Scrolling() {
		//if (gameObject.name == "BG0") {
			transform.Translate (new Vector3 (scrollSpeed, 0));
		//}	
		//else {
		//	transform.Translate (new Vector3 (-scrollSpeed, 0));
		//}
	}

	public void ResetScrolling() {
		transform.localPosition = anchorBG.localPosition;
	}
}
