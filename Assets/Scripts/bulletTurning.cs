using UnityEngine;
using System.Collections;

public class bulletTurning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(turning.orientatedLeft == true){
			transform.Rotate(Vector3.down * (Time.deltaTime + 2));
		}else if(turning.orientatedRight == true){
			transform.Rotate(Vector3.up * (Time.deltaTime + 2));
		}
	}
}
