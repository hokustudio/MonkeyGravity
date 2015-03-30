using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour {
	public GameObject win;
	public GameObject lose;
	public GameObject input;
	private int temp=0;
	private int skor=0;
	public Text text;

	private static GameFinish singleton;
	
	public static GameFinish myInstance {
		get {
			return singleton;
		}
	}

	// Use this for initialization
	void Start () {
		singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (temp < skor) {
			temp+=5;
		}
		text.text = temp.ToString ();
	}

	void OnTriggerEnter2D(Collider2D x) {
		Debug.Log("Finnish");
		StartCoroutine (Win ());
	}
	IEnumerator Win()
	{
		//input.SetActive (false);
		yield return new WaitForSeconds(3.0f);
		win.transform.position = new Vector3 (0f,0f,0f);
		int score = GoldManagerScript.myInstance.getCurrentGold ();
		skor = score * 100;
		yield return new WaitForSeconds(1.0f);
		int i = 0;
		bool p = true;
		while (p){
			win.transform.GetChild (3).transform.GetChild (i).gameObject.SetActive(true);
			i++;
			score--;
			if(score<1) p=false;
			yield return new WaitForSeconds(1.0f);
		}
	}

	public void Lose(){
		StartCoroutine (Kalah ());
	}
	
	IEnumerator Kalah()
	{
		//input.SetActive (false);
		yield return new WaitForSeconds(1.0f);
		lose.transform.position = new Vector3 (0f,0f,0f);
	}
}
