using UnityEngine;
using System.Collections;

public class PlayerPhysic : MonoBehaviour
{
	private float maxFuelTank; // default 350
	private float fuelTank;
	private float maxPlayerStrength; // default 1
	private float playerStrength;

	private float thrustMaxSpeed; //thrust force max default 1800 / mass 100 
	private float revThrustMaxSpeed; //-200
	private float thrustAcceleration; //thrust acc default 275
	private float thrustCurrentSpeed;
	private float rotationSpeed; //rotation speed default 4

	public ParticleSystem thrustParticleEffect;
	public GameObject explosion;
	public Animator Animator;

	private Rigidbody2D rb;
	private static PlayerPhysic singleton;

	public static PlayerPhysic myInstance {
		get {
			return singleton;
		}
	}

	void Start ()
	{
		singleton = this;
		rb = GetComponent<Rigidbody2D> ();

		//initilize Player
		thrustMaxSpeed = PlayerModels.PlayerInstance.GetMaxSpeedPlayer ();
		thrustAcceleration = PlayerModels.PlayerInstance.GetAccelerationPlayer ();
		revThrustMaxSpeed = PlayerModels.PlayerInstance.GetRevMaxSpeedPlayer ();
		rotationSpeed = PlayerModels.PlayerInstance.GetRotationSpeedPlayer ();
		fuelTank = PlayerModels.PlayerInstance.GetFuelPlayer ();
		playerStrength = PlayerModels.PlayerInstance.GetStrengthPlayer ();
	}

	void Update ()
	{
		Debug.Log (thrustMaxSpeed);
		if (thrustCurrentSpeed > 0) {
			thrustCurrentSpeed = thrustCurrentSpeed + revThrustMaxSpeed;

		}

		var x = rb.velocity.x;
		Vector2 smooth;

		smooth.x = 36;

		if (rb.velocity.y < 0) {
			if (Mathf.Abs (rb.velocity.x) > 0) {
				x = Mathf.Lerp (x / 1.015f, rb.velocity.x, smooth.x * Time.deltaTime);

				rb.velocity = new Vector2 (x, rb.velocity.y);
			}
		}

		Animator.SetFloat ("Speed", thrustCurrentSpeed);
	}


	public void ThrustForce ()
	{
		if (thrustCurrentSpeed < thrustMaxSpeed) {
			float newspeed = thrustCurrentSpeed + thrustAcceleration;
			thrustCurrentSpeed = newspeed;
		}

		if (gameObject != null) {
			if (fuelTank > 0) {
				rb.AddForce (transform.up * thrustCurrentSpeed);
				thrustParticleEffect.Play ();
				PlayerModels.PlayerInstance.SetFuelPlayer (--fuelTank);
			} else {
				thrustParticleEffect.Stop ();
				//FuelPlayerHandler ();
			}
		} 
	}

	public void ThrustForceStop ()
	{
		if(thrustParticleEffect != null)
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

	public void StrengthPlayerHandler ()
	{
		if (playerStrength > 1) {
			PlayerModels.PlayerInstance.SetStrengthPlayer(--playerStrength);
		} else {
			ExplodePlayer();
			GameFinish.myInstance.Lose();
			Destroy (gameObject);
		}

	}

	public void FuelPlayerHandler ()
	{
			ExplodePlayer();
			GameFinish.myInstance.Lose();
			Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Bounds") {
			ExplodePlayer();
			GameFinish.myInstance.Lose();
			rb.isKinematic = true;
			Destroy (gameObject);
		}
	}

	public void ExplodePlayer()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
