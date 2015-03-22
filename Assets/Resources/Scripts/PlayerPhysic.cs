using UnityEngine;
using System.Collections;

public class PlayerPhysic : MonoBehaviour
{
	public int maxFuelTank = 5000;
	private int fuelTank;
	public int maxPlayerStrength = 3;
	private int playerStrength;
	
	public float thrustMaxSpeed = 1800; //thrust force max default 1700 / mass 100 
	private float revThrustMaxSpeed = -200;
	private float thrustMinSpeed = 100;
	public float thrustAcceleration; //thrust
	private float thrustLeftAcceleration = 300;
	private float thrustRightAcceleration = 100;
	public float thrustCurrentSpeed = 0;

	public float rotationSpeed=5; //rotation speed default 150

	public ParticleSystem thrustParticleEffect;
	private Rigidbody2D rb;

	private static PlayerPhysic singleton;

	public static PlayerPhysic myInstance {
		get {
			return singleton;
		}
	}

	// Use this for initialization
	void Start ()
	{
		singleton = this;
		rb = GetComponent<Rigidbody2D> ();
		fuelTank = maxFuelTank;
		playerStrength = maxPlayerStrength;
		//mRot = transform.rotation.eulerAngles; 
	}

	// Update is called once per frame
	void Update ()
	{
		if (thrustCurrentSpeed > 0) {
			thrustCurrentSpeed = thrustCurrentSpeed + revThrustMaxSpeed;
		}

		var x = rb.velocity.x;
		Vector2 smooth;

		smooth.x = 36;

		if (rb.velocity.y < 0) {
			if(Mathf.Abs(rb.velocity.x) > 0) {
				x = Mathf.Lerp(x/1.015f, rb.velocity.x, smooth.x * Time.deltaTime);

				rb.velocity = new Vector2(x, rb.velocity.y);
			}
		}
		//Debug.Log (GetComponent<Rigidbody2D> ().velocity + " " + x);
		thrustParticleEffect.Stop ();
	}

	public int GetFuel(){
		return fuelTank;
	}
	public int GetMaxFuel(){
		return maxFuelTank;
	}

	public int GetStrength(){
		return playerStrength;
	}
	public int GetMaxStrength(){
		return maxPlayerStrength;
	}

	public void ThrustForce ()
	{
		if (thrustCurrentSpeed < thrustMaxSpeed) {
			float newspeed = thrustCurrentSpeed + thrustAcceleration;
			thrustCurrentSpeed = newspeed;
		}
		//Debug.Log (fuelTank);
		if (fuelTank > 0) {
			rb.AddForce (transform.up * thrustCurrentSpeed);
			thrustParticleEffect.Play ();
			fuelTank--;
		} else {
			thrustParticleEffect.Stop ();
		}
	}

	public void ThrustForceStop ()
	{
		thrustParticleEffect.Stop ();
	}

	public void RotationRight ()
	{
		transform.Rotate (transform.rotation.x, transform.rotation.y, transform.rotation.z - rotationSpeed);
	}

	public void RotationLeft ()
	{
		transform.Rotate (transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationSpeed);
	}

	public void StrenghtPlayerHandler ()
	{
		if (playerStrength >= 1) {
			playerStrength--;
		} else {
			Debug.Log ("Animasi Meledak");
			Application.LoadLevel(0);
		}

	}
}
