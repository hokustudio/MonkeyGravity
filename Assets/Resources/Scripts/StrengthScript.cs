using UnityEngine;
using System.Collections;

public class StrengthScript : MonoBehaviour {
	private int maxStrength;
	private int strength;
	private float x;
	private float rx;
	private float y;

	// Use this for initialization
	void Start () {
		rx = transform.localScale.x;
		strength = maxStrength;
	}
	
	// Update is called once per frame
	void Update () {
		maxStrength = PlayerPhysic.myInstance.GetMaxStrength();
		strength = PlayerPhysic.myInstance.GetStrength();
		x = rx * strength / maxStrength;
		y = transform.localScale.y;
		transform.localScale = new Vector2(x,y);
	}
}
