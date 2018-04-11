using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRender : MonoBehaviour {

	public GameObject cam;

	void Update() {
		if (Input.GetButtonDown ("Fire1")) {

			Vector3 mp = Input.mousePosition;
			Camera ca = cam.GetComponent<Camera> ();
			Ray ray = ca.ScreenPointToRay(Input.mousePosition);

			RaycastHit[] hits;
			hits = Physics.RaycastAll (ray);

			for (int i = 0; i < hits.Length; i++) {
				RaycastHit hit = hits [i];
				Renderer rend = hit.transform.GetComponent<Renderer> ();

				if (rend) {
					// Change the material of all hit colliders
					// to use a transparent shader.
					rend.material.shader = Shader.Find ("Transparent/Diffuse");
					Color tempColor = rend.material.color;
					tempColor.a = 0.3F;
					rend.material.color = tempColor;
				}
			}
		}
	}
}
