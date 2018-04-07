using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene Controller
/// Usage: host on a gameobject in the scene   
/// responsiablities:
///   acted as a scene manager for scheduling actors.log something ...
///   interact with the director and players
/// </summary>
public class FirstController : MonoBehaviour, ISceneController, IUserAction {

	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
	}
	 
	// loading resources for the first scence
	public void LoadResources () {
		GameObject sunset = Instantiate<GameObject> (
			                    Resources.Load <GameObject> ("prefabs/sun"),
			                    Vector3.zero, Quaternion.identity);
		sunset.name = "sunset";
		Debug.Log ("load sunset ...\n");
	}

	public void Pause ()
	{
		throw new System.NotImplementedException ();
	}

	public void Resume ()
	{
		throw new System.NotImplementedException ();
	}

	#region IUserAction implementation
	public void GameOver ()
	{
		SSDirector.getInstance ().NextScene ();
	}
	#endregion


	// Use this for initialization
	void Start () {
		//give advice first
	}
	
	// Update is called once per frame
	void Update () {
		//give advice first
	}

}
