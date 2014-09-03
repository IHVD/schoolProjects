using UnityEngine;
using System.Collections;
//using System;

public class randomRangeTest : MonoBehaviour {

	public static float randomRange;
	public float rotationPerSecond;

	public static float rotation;

	void Update () {
		if (Input.GetKey ("left")) {
			transform.Rotate(Vector3.forward * Time.deltaTime * rotationPerSecond);
		}if (Input.GetKey ("right")) {
			transform.Rotate(Vector3.back * Time.deltaTime * rotationPerSecond);
		}
		rotation = transform.rotation.eulerAngles.z;
	}

	void OnGUI(){
		//guiText.text = randomRange.ToString();
	}
}
