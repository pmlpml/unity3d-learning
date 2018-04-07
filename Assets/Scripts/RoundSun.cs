using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSun : MonoBehaviour {

	public Transform sun;
	public Transform earth;
	public Transform moon;

	// Use this for initialization
	void Start () {
		sun.position = Vector3.zero;
		earth.position = new Vector3 (6, 0, 0);
		moon.position = new Vector3 (8, 0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		earth.RotateAround(sun.position, Vector3.up, 10 * Time.deltaTime);
		earth.Rotate (Vector3.up * 30 * Time.deltaTime);
		moon.transform.RotateAround(earth.position, Vector3.up, 359 * Time.deltaTime);
	}
}
