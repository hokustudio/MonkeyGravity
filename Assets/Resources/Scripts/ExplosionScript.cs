using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{

	void OnAnimationFinish ()
	{
		Destroy (gameObject);
	}
}
