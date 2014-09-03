using UnityEngine;
using System.Collections;

public class cannonBarrel : MonoBehaviour {

	public int tiltX;
	public int tiltY;
	public float tiltZ;
	public GameObject barrel;

	// Update is called once per frame
	void Update () {
		tiltZ = randomRangeTest.randomRange;
		transform.Rotate (tiltX, tiltY, tiltZ);
		/*Quaternion barrel = Quaternion.Euler(tiltX, tiltY, randomRangeTest.randomRange);
		transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, barrel);*/
		//Quaternion rotation = Quaternion.Euler(new Vector3(0, 30, randomRangeTest.randomRange));
	}
}