using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class moveScript : MonoBehaviour {
	
	public Vector3 launchVelocity;
	public Vector3 airResistance;

	public int lives;
	public GUIText livesLeft;

	public static bool Bouncy;
	public static bool liftOff;
	public static Vector3 velocity;

	void Awake(){
		DontDestroyOnLoad(this);
	}

	void Start(){
		velocity = new Vector3();
		liftOff = false;
	}
	
	void Update () {
		//Press the spacebar, and liftOff == true.
		if(Input.GetButton ("Jump") && !liftOff){
			liftOff = true;

			// Rotation has been corrected with 90 degrees as the model is 90 degrees off
			float radiansTiltZ = (float)((randomRangeTest.rotation - 90) * (Math.PI / 180));
			print (string.Format ("{0} degrees -> {1} radians", randomRangeTest.rotation, radiansTiltZ));

			// Create an angle vector based on the rotation of the cannon
			// The formula used is called "Rotation Matrix" but I only use it on one axis
			Vector3 angleDirection = new Vector3((float) -Math.Cos(radiansTiltZ), (float) -Math.Sin(radiansTiltZ));
			// Normalize it so it gets a length of 1, this is used to keep the initial velocity length intact
			// Without this the rotation might change the length of the launchVelocity
			angleDirection.Normalize();

			velocity = angleDirection;
			velocity.Scale(launchVelocity); // Scaling is the same as multiplying
			print ("Fire ze cannons!");
		}

		livesLeft.text = "Lives left: " + lives.ToString();

		if (transform.position.y < -5f) {
			lives-= 1;
			reset();
		}
		if (velocity.x <= 0.0F) {
			velocity.y = 0.0F;
		}

		//if liftOff == true, the box will start moving.
		if (!liftOff)
			return;
		
		Vector3 resistance = new Vector3 (Math.Min (velocity.x, airResistance.x), airResistance.y, airResistance.z);
		velocity -= (resistance * Time.deltaTime);
		transform.position += velocity;
		
		if (!triggers.Hit) {
			// No collisions detected
			return;
		}

		// Take the absolute value of the Y velocity so the bullet will go up again
		// The box loses 10% of its energy in order to invert the direction
		velocity.y = Math.Abs (velocity.y * 0.90f);

		if (lives <= 0) {
			Application.LoadLevel(1);
		}

		if (Bouncy) {
			// We're especially bounce today and we gain energy out of no where
			velocity.y += rocket.verticalBounce;
			Bouncy = false;
		}

		print(string.Format ("Collision at {1}, New Velocity: {0}", velocity, transform.position));
		triggers.Hit = false;
	}
	void reset(){
		transform.position = new Vector3 (-85F, 3.5F, 0F);
		liftOff = false;
	}
}