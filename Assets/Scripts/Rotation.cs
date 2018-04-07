using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//  ??? 
		this.transform.Rotate (Vector3.up * 30 * Time.deltaTime);	
		//  ???
		this.transform.RotateAround ( Vector3.zero, Vector3.up, 30 * Time.deltaTime);
		//   ???
		this.transform.RotateAround (- Vector3.left * 2.5f, Vector3.up, 30 * Time.deltaTime);
	}
}
