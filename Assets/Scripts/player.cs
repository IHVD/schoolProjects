using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Transform bullet;


	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Jump")){

		}
		if (Input.GetKey("a")){
			Rigidbody clone;
			clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 10);
		}
	}
}
