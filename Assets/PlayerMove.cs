using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{

	public GameObject bulletPrefab;

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}

	void Update()
	{
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire();
		}
	}

	[Command]
	void CmdFire()
	{
		// This [Command] code is run on the server!

		// create the bullet object locally
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			transform.position - transform.forward,
			Quaternion.identity);

		bullet.GetComponent<Rigidbody>().velocity = -transform.forward*4;

		// spawn the bullet on the clients
		NetworkServer.Spawn(bullet);

		// when the bullet is destroyed on the server it will automaticaly be destroyed on clients
		Destroy(bullet, 2.0f);      
	}
}
