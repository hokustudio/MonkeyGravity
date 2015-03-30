using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldManagerScript : MonoBehaviour
{

	public static float banana;
	public Text skorText;
	Text text;
	private static GoldManagerScript singleton;

	public static GoldManagerScript myInstance {
		get {
			return singleton;
		}
	}

	void Start ()
	{
		banana = PlayerModels.PlayerInstance.GetBananaPlayer ();
		singleton = this;
		skorText = skorText.GetComponent<Text> ();
	}

	void Update ()
	{
		skorText.text = banana.ToString ();
	}
	
	public void AddBanana ()
	{
		PlayerModels.PlayerInstance.SetBananaPlayer (++banana);
	} 
}
