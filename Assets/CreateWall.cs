using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Create wall.
/// 
/// Now we only need to create the Prefab, which we do in the Editor. Here’s how:
///
/// 1.Choose GameObject > Create General > Cube
/// 2.Choose Component > Physics > Rigidbody
/// 3.Choose Assets > Create > Prefab
/// 4.In the Project View, change the name of your new Prefab to “Brick”
/// 5.Drag the cube you created in the Hierarchy onto the “Brick” Prefab in the Project View
/// 6.With the Prefab created, you can safely delete the Cube from the Hierarchy
///
/// We’ve created our Brick Prefab, so now we have to attach it to the brick variable in our script.
/// </summary>
public class CreateWall : MonoBehaviour {

	public Transform brick;

	void Start () {
		BuildWall ();
	}

	public void BuildWall() {
		GameObject wall = new GameObject ("A Wall");
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				Transform br = Instantiate<Transform> (brick, new Vector3(x, y, 0), Quaternion.identity);
				br.name = "brick_" + x.ToString () + "_" + y.ToString ();
				br.parent = wall.transform;
			}
		}
	}
}
