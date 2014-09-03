using UnityEngine;
using System.Collections;

public class turning : MonoBehaviour {

	public static bool orientatedLeft = false;
	public static bool orientatedRight = false;
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKey("left")){
			transform.Rotate(Vector3.down * (Time.deltaTime + 1));
			orientatedLeft = true;

		}if (Input.GetKey ("right")) {
			transform.Rotate (Vector3.up * (Time.deltaTime + 1));
			orientatedRight = true;
		} 
	}
}