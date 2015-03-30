using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D collision)
	{
		PlayerPhysic.myInstance.StrengthPlayerHandler ();
	}
}
