using UnityEngine;
using System.Collections;

public class triggers : MonoBehaviour {

	public static bool Hit = false;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Ground") {
			Hit = true;
		}
	}
}
