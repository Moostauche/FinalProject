using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // setting the framerate of the game - 60FPS is the industry standard
        Application.targetFrameRate = 60;
	}
	
	// When the button is pressed start the new scene "Game"
	public void PlayGame () {
        SceneManager.LoadScene("Game");
	}
}


