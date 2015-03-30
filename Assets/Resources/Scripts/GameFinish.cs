using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
	public GameObject win;
	public GameObject lose;
	public GameObject input;
	public Text text;
	
	private float temp = 0;
	private float score = 0;
	private float finishScore = 35000;
	private float timeCounter = 10;

	private static GameFinish singleton;
	
	public static GameFinish myInstance {
		get {
			return singleton;
		}
	}

	void Start ()
	{
		singleton = this;
	}

	void Update ()
	{
		if (temp < score) {
			temp += 300;
		}
		text.text = temp.ToString ();

		//if(temp > 25000)
		//	win.transform.GetChild (3).transform.GetChild (0).gameObject.SetActive (true);
		//else if(temp > 55000)
		//	win.transform.GetChild (3).transform.GetChild (1).gameObject.SetActive (true);
		//else if(temp > 83000)
		//	win.transform.GetChild (3).transform.GetChild (2).gameObject.SetActive (true);

		timeCounter -= 1 * Time.deltaTime;
		Debug.Log (temp);
	}

	public int TimeCounter() 
	{
		return (int)timeCounter;
	}

	public float FinishScore ()
	{
		return finishScore;
	}

	void OnTriggerEnter2D (Collider2D x)
	{
			Debug.Log ("Finnish");
			StartCoroutine (Win ());
	}

	IEnumerator Win ()
	{
		//input.SetActive (false);
		yield return new WaitForSeconds (2.0f);
		win.transform.position = new Vector3 (0f, 0f, 0f);
		float score = PlayerModels.PlayerInstance.GetBananaPlayer ();

		score = CalculateScore.myInstance.ScorePlayer ();
		Debug.Log (score);
		yield return new WaitForSeconds (1.0f);
		int i = 0;
		bool p = true;
		while (p) {
			win.transform.GetChild (3).transform.GetChild (i).gameObject.SetActive (true);
			i++;
			score--;
			if (score < 1)
			p = false;
			yield return new WaitForSeconds (1.0f);
		}
	}

	public void Lose ()
	{
		StartCoroutine (Losed ());
	}
	
	IEnumerator Losed ()
	{
		//input.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		lose.transform.position = new Vector3 (0f, 0f, 0f);
	}
}
