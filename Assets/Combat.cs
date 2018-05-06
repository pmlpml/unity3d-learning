using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour {

	public const int maxHealth = 100;
	public bool destroyOnDeath;

	[SyncVar]
	public int health = maxHealth;

	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;
		
		health -= amount;
		Debug.Log("health value = " + health.ToString());
		if (health <= 0)
		{
			if (destroyOnDeath)
			{
				print("Destory");
				Destroy(gameObject);
			}
			else
			{
				health = maxHealth;

				// called on the server, will be invoked on the clients
				RpcRespawn();
			}
		}
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			// move back to zero location
			transform.position = Vector3.zero;
		}
	}
}
