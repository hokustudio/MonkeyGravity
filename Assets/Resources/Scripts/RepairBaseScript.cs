using UnityEngine;
using System.Collections;

public class RepairBaseScript : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D collision)
	{		
		PlayerModels.PlayerInstance.RepairStrength ();
	}
}
