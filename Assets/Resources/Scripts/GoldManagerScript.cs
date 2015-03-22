using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldManagerScript : MonoBehaviour {

	public static int gold;
	public Text skorText;
	Text text;
	private static GoldManagerScript singleton;
	public static GoldManagerScript myInstance {
		get {
			return singleton;
		}
	}

	public int getCurrentGold(){
		return gold;
	}
	public void addGold(){
		gold++;
		//Debug.Log (gold);
	} 

	// Use this for initialization
	void Start () {
		gold = 0;
		singleton = this;
		skorText = skorText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		skorText.text =  gold.ToString();
	}
}
