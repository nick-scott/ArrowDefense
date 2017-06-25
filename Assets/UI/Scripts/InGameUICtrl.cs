using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUICtrl : MonoBehaviour {
	
	public bool isPaused;
	public GameObject inGameUI;
	public GameObject pauseMenu;
	public GameObject settingsMenu;

	// Update is called once per frame
	void Update () {
		if(isPaused){
			Time.timeScale = 0f;
		}
		else {
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			isPaused = !isPaused;
		}
	}

	public void Pause(){
		isPaused = true;
		inGameUI.SetActive (false);
		pauseMenu.SetActive (true);
	}

	public void Resume(){
		isPaused = false;
		pauseMenu.SetActive (false);
		inGameUI.SetActive (true);

	}

	public void Settings(){
		pauseMenu.SetActive (false);
		settingsMenu.SetActive (true);
	}

	public void ReturnToPauseMenu(){
		settingsMenu.SetActive (false);
		pauseMenu.SetActive (true);
	}

	public void Quit(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
