using UnityEngine;
using System.Collections;

public class BananaScript : MonoBehaviour
{
	void Update(){
	}

	void OnTriggerEnter2D (Collider2D collision)
	{
		Destroy (gameObject);
		GoldManagerScript.myInstance.addGold ();
	}
}
