using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	void FixedUpdate () {
		Rigidbody rigid = this.gameObject.GetComponent<Rigidbody> ();
		if (rigid) {
			rigid.AddForce (Vector3.down * 9.8f);
		}
	}
}
