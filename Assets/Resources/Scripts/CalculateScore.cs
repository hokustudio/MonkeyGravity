using UnityEngine;
using System.Collections;

public class CalculateScore : MonoBehaviour {

	private static CalculateScore singleton;
	
	public static CalculateScore myInstance {
		get {
			return singleton;
		}
	}

	void Start()
	{
		singleton = this;
	}

	public float ScorePlayer()
	{
		float maxstrength = PlayerModels.PlayerInstance.GetMaxStrengthPlayer ();
		float maxfuel = PlayerModels.PlayerInstance.GetMaxFuelPlayer ();

		float banana = PlayerModels.PlayerInstance.GetBananaPlayer ();
		float strength = PlayerModels.PlayerInstance.GetStrengthPlayer ();
		float fuel = PlayerModels.PlayerInstance.GetFuelPlayer ();

		float time = GameFinish.myInstance.TimeCounter ();
		float bonusPercent = 100000*30/100;
		float bonus = (((time * 10f) + (fuel / (maxfuel/100f)) + (strength / (maxstrength / 100f)) + (banana / (banana / 100f))) / 400) * bonusPercent;

		float strengthPercent = 100000*25/100;
		strength = strength / maxstrength;

		float fuelPercent = 100000*10/100;
		fuel = fuel / maxfuel;


		strength *= strengthPercent;
		fuel *= fuelPercent;
		float finishScore = GameFinish.myInstance.FinishScore ();

		float score = strength + fuel + finishScore + bonus;

		return score;
	}
}
