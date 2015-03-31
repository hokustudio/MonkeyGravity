using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
	public GameObject win;
	public GameObject lose;
	public GameObject kamera;
	public Text text;
	
	private float temp = 0;
	private float score = 0;
	private float finishScore = 35000;
	private float timeCounter = 20;
	private float counterWin = 0;

	private bool w = false;
	private bool l = false;

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
	float y1 = 1.5f, y2 = -1.3f,s=1f;
	
	bool masuk = false;

	void FixedUpdate ()
	{
		if (masuk) {
			counterWin += 1 * Time.deltaTime;
		}
		if(l && y1<4.8 && y2>-4.8){
			lose.transform.FindChild("Frame Atas").transform.localPosition = new Vector2(0f,y1+=0.2f);
			lose.transform.FindChild("Frame Bawah").transform.localPosition = new Vector2(0f,y2-=0.2f);
			if(s<=2){
				lose.transform.FindChild("Box").transform.localScale = new Vector2(2f,s+=0.2f);
			}
		}
		if(w && y1<4.8 && y2>-4.8){
			win.transform.FindChild("Frame Atas").transform.localPosition = new Vector2(0f,y1+=0.2f);
			win.transform.FindChild("Frame Bawah").transform.localPosition = new Vector2(0f,y2-=0.2f);
			if(s<=2){
				win.transform.FindChild("Box").transform.localScale = new Vector2(2f,s+=0.2f);
			}
		}

		if (temp < score) {
			temp += 300;
		}
		text.text = temp.ToString ();

		if(temp > 25000)
			win.transform.FindChild("Box").transform.FindChild("Star").transform.GetChild (0).gameObject.SetActive (true);
		if(temp > 55000)
			win.transform.FindChild("Box").transform.FindChild("Star").transform.GetChild (1).gameObject.SetActive (true);
		if(temp > 83000)
			win.transform.FindChild("Box").transform.FindChild("Star").transform.GetChild (2).gameObject.SetActive (true);

		timeCounter -= 1 * Time.deltaTime;
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
		masuk = true;
	}
	void OnTriggerStay2D (Collider2D x){
		if (counterWin > 2) {
			Debug.Log ("Finish");
			StartCoroutine (Win ());
		}
	}
	void OnTriggerExit2D (Collider2D x){
		masuk = false;
		Debug.Log (0);

	}

	IEnumerator Win ()
	{
		//input.SetActive (false);
		yield return new WaitForSeconds (2.0f);
		win.transform.parent = kamera.transform;
		win.transform.localPosition = new Vector3 (0f, 0f, 10f);
		//score = PlayerModels.PlayerInstance.GetBananaPlayer ();
		yield return new WaitForSeconds (0.5f);
		w = true;
		score = CalculateScore.myInstance.ScorePlayer ();
		Debug.Log (score);
		//yield return new WaitForSeconds (1.0f);
		//int i = 0;
		//bool p = true;
		//while (p) {
		//	win.transform.GetChild (3).transform.GetChild (i).gameObject.SetActive (true);
		//	i++;
		//	score--;
		//	if (score < 1)
		//	p = false;
		//	yield return new WaitForSeconds (1.0f);
		//}
	}

	public void Lose ()
	{
		StartCoroutine (Losed ());
	}
	
	IEnumerator Losed ()
	{
		//input.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		lose.transform.parent = kamera.transform;
		lose.transform.localPosition = new Vector3 (0f, 0f, 10f);
		yield return new WaitForSeconds (0.5f);
		l = true;
	}
}
