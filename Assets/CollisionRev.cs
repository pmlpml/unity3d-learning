using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRev : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Collision @ " + Time.frameCount.ToString());
		Debug.Log ("GameObject is :" + collision.gameObject.name);
		if (collision.collider) Debug.Log ("Collider belong to :" + collision.collider.gameObject.name);
		if (collision.rigidbody) Debug.Log ("Rigidbody belong to :" + collision.rigidbody.gameObject.name);
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.white);
		}
	}
}
