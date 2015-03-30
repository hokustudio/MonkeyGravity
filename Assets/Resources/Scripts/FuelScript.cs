using UnityEngine;
using System.Collections;

public class FuelScript : MonoBehaviour
{

	private float maxFuel;
	private float fuel;
	private float x;
	private float rx;
	private float y;

	// Use this for initialization
	void Start ()
	{
		rx = transform.localScale.x;
		fuel = maxFuel;
	}
	
	// Update is called once per frame
	void Update ()
	{
		maxFuel = PlayerModels.PlayerInstance.GetMaxFuelPlayer ();
		fuel = PlayerModels.PlayerInstance.GetFuelPlayer ();
		x = rx * fuel / maxFuel;
		y = transform.localScale.y;
		transform.localScale = new Vector2 (x, y);
	}
}
