using UnityEngine;
using System.Collections;

public class FuelBaseScript : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D collision)
	{		
		PlayerModels.PlayerInstance.FuelTank ();
	}
}
