using UnityEngine;
using System.Collections;

public class PlayerModels : MonoBehaviour {

	private float maxSpeedPlayer;
	private float accelerationPlayer;
	private float revMaxSpeedPlayer;
	private float rotationSpeedPlayer;
	
	private float maxStrengthPlayer;
	private float strengthPlayer;
	private float maxFuelPlayer;
	private float fuelPlayer;
	private float bananaPlayer;
	private float orbsPlayer;
	
	
	private static PlayerModels singleton;
	public static PlayerModels PlayerInstance {
		get {
			return singleton;
		}
	}
	
	//constructor
	void Start() {
		maxSpeedPlayer = 1800;
		accelerationPlayer = 275;
		revMaxSpeedPlayer = -200;
		rotationSpeedPlayer = 4;
		
		maxStrengthPlayer = 2;
		strengthPlayer = maxStrengthPlayer;
		maxFuelPlayer = 350;
		fuelPlayer = maxFuelPlayer;
		bananaPlayer = 0;
		orbsPlayer = 0;
		singleton = this;
	}
	
	public float GetMaxSpeedPlayer() {
		return maxSpeedPlayer;
	}
	
	public float GetAccelerationPlayer() {
		return accelerationPlayer;
	}
	
	public float GetRevMaxSpeedPlayer() {
		return revMaxSpeedPlayer;
	}
	
	public float GetRotationSpeedPlayer() {
		return rotationSpeedPlayer;
	}
	
	public float GetMaxStrengthPlayer() {
		return maxStrengthPlayer;
	}
	
	public float GetStrengthPlayer() {
		return strengthPlayer;
	}
	
	public float GetMaxFuelPlayer() {
		return maxFuelPlayer;
	}
	
	public float GetFuelPlayer() {
		return fuelPlayer;
	}
	
	public float GetBananaPlayer() {
		return bananaPlayer;
	}
	
	public float GetOrbsPlayer() {
		return orbsPlayer;
	}
	
	public void SetFuelPlayer(float currentFuel) {
		fuelPlayer = currentFuel;
	}
	
	public void SetStrengthPlayer(float currentStrength) {
		strengthPlayer = currentStrength;
	}

	public void SetBananaPlayer(float currentBanana) {
		bananaPlayer = currentBanana;
	}
	
	public void FuelTank ()
	{
		fuelPlayer = maxFuelPlayer;
	}
	
	public void RepairStrength ()
	{
		strengthPlayer = maxStrengthPlayer;
	}
}
