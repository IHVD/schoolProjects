using UnityEngine;
using System.Collections;

public class PlayerRocket : MonoBehaviour {
	
	public Vector3 boostVelocity;
	public int boostsLeft;
	private float timeSinceLastNewBoost;
	public GUIText rocketBoosterLeft;
	
	void Start(){
	}
	
	void Update(){

		rocketBoosterLeft.text = "Amount of Rockets Left: " + boostsLeft;

		if (!moveScript.liftOff) {
			// We're not flying yet
			return;
		}

		timeSinceLastNewBoost += Time.deltaTime;
		while ((timeSinceLastNewBoost > 1) && (boostsLeft <= 9)) {
			timeSinceLastNewBoost -= 1;
			++boostsLeft;
		}

		if (!Input.GetMouseButtonDown (0)) {
			// We're not holding the button down
			return;
		}

		if (boostsLeft == 0) {
			return;
		}

		moveScript.velocity += boostVelocity;
		--boostsLeft;
	}
}