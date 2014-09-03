 using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {

	public float horizontalBoost;
	public float verticalBoost;
	public bool isPlayer = false;
	public static float verticalBounce;

	void Start(){
		if (tag == "Player") {
			isPlayer = true;
		} else {
			isPlayer = false;
		}
		verticalBounce = verticalBoost;
	}

	void OnTriggerEnter(Collider other){
		if (isPlayer == false) {
			if (other.tag == "Player" && tag == "RocketVertical") {
				moveScript.velocity.y += verticalBoost;
			}if (other.tag == "Player" && tag == "RocketHorizontal") {
				moveScript.velocity.x += horizontalBoost;
			}if (other.tag == "Player" && tag == "RocketBoth") {
				moveScript.velocity.y += verticalBoost;
				moveScript.velocity.x += horizontalBoost;
			}if (other.tag == "Player" && tag == "BouncyBall") {
				print ("bounce!");
				moveScript.Bouncy = true;
			}
		}
	}

	void Update(){
		if (moveScript.liftOff == true) {
			if (tag == "Player" && Input.GetMouseButton (0)) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5F, 0);
			}
		}
	}
}