using UnityEngine;
using System.Collections;

public class FuelScript : MonoBehaviour {
	private int maxFuel;
	private int fuel;
	private float x;
	private float rx;
	private float y;

	// Use this for initialization
	void Start () {
		rx = transform.localScale.x;
		//maxFuel = PlayerPhysic.myInstance.getMaxFuel();
		fuel = maxFuel;
	}
	
	// Update is called once per frame
	void Update () {
		maxFuel = PlayerPhysic.myInstance.GetMaxFuel();
		fuel = PlayerPhysic.myInstance.GetFuel();
		x = rx * fuel / maxFuel;
		y = transform.localScale.y;
		transform.localScale = new Vector2(x,y);
		//Debug.Log ("Fuel: "+fuel+" x: "+x);
	}
}
