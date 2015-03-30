using UnityEngine;
using System.Collections;

public class StrengthScript : MonoBehaviour
{
	private float maxStrength;
	private float strength;
	private float x;
	private float rx;
	private float y;

	void Start ()
	{
		rx = transform.localScale.x;
		strength = maxStrength;
	}

	void Update ()
	{
		maxStrength = PlayerModels.PlayerInstance.GetMaxStrengthPlayer ()-1;
		strength = PlayerModels.PlayerInstance.GetStrengthPlayer ()-1;
		x = rx * strength / maxStrength;
		y = transform.localScale.y;
		transform.localScale = new Vector2 (x, y);
	}
}
