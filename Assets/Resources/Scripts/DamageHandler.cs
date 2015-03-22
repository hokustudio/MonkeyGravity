using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	private int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		damage = 0;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("ketabrak");

		PlayerPhysic.myInstance.StrenghtPlayerHandler ();
	}
}
