using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour {

	public float speedX = 10.0F;
	public float speedY = 10.0F;
	//public GameObject cam;

	void Start () {
		DiskFactory df = Singleton <DiskFactory>.Instance;
	}

	void Update () {
		float translationY = Input.GetAxis("Vertical") * speedY;
		float translationX = Input.GetAxis("Horizontal") * speedX;
		translationY *= Time.deltaTime;
		translationX *= Time.deltaTime;
		//transform.Translate(0, translationY, 0);
		//transform.Translate(translationX, 0, 0);
		transform.Translate(translationX, translationY, 0);
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log ("Fired Pressed");
			Debug.Log (Input.mousePosition);

			Vector3 mp = Input.mousePosition; //get Screen Position

			//create ray, origin is camera, and direction to mousepoint
			Camera ca = Camera.main; //cam.GetComponent<Camera> ();
			Ray ray = ca.ScreenPointToRay(Input.mousePosition);

			//Return the ray's hit
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				print (hit.transform.gameObject.name);
				if (hit.collider.gameObject.tag.Contains("Finish")) { //plane tag
					Debug.Log ("hit " + hit.collider.gameObject.name +"!" ); 
				}
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
