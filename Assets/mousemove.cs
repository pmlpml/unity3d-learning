using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemove : MonoBehaviour {

	public float speedX = 10.0F;
	public float speedY = 10.0F;
	
	// Update is called once per frame
	void Update () {
		float translationY = Input.GetAxis("Mouse Y") * speedY;
		float translationX = Input.GetAxis("Mouse X") * speedX;
		translationY *= Time.deltaTime;
		translationX *= Time.deltaTime;
		//transform.Translate(0, translationY, 0);
		//transform.Translate(translationX, 0, 0);	
		transform.Translate(translationX, translationY, 0);
	}
}
