using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {
	void Start(){
		//Debug.Log(111);
	}

	public void LoadScene(int level){
		//Debug.Log(222);
		Application.LoadLevel(level);
		//Debug.Log(333);
	}
}
