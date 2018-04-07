using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

	private IUserAction action;

	void Start () {
		action = SSDirector.getInstance ().currentSceneController as IUserAction;
	}

	void OnGUI() {  
		float width = Screen.width / 6;  
		float height = Screen.height / 12; 

		if (GUI.Button(new Rect(0, 0, width, height), "Game Over!")) {  
			action.GameOver();  
		} 

		string paused_title = SSDirector.getInstance ().Paused ? "Resume" : "Pause!"; 
		if (GUI.Button(new Rect(width, 0, width, height), paused_title)) { 
			SSDirector.getInstance ().Paused = !SSDirector.getInstance ().Paused;
		} 
	}


}
