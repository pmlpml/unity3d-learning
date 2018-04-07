using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// ???
		this.transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		// ???
		this.transform.rotation *= Quaternion.AngleAxis(30 * Time.deltaTime, Vector3.up);
	}
}
