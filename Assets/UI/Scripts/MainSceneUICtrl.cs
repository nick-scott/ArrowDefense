using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneUICtrl : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvas;
	public GameObject inGameCanvas;

	// Update is called once per frame
	void Update () {
		if(isPaused){
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		}
		else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			isPaused = !isPaused;
		}
	}

	public void Pause(){
		isPaused = true;
		inGameCanvas.SetActive (false);
	}

	public void Resume(){
		isPaused = false;
		inGameCanvas.SetActive (true);
	}

	public void Settings(){

	}

	public void Quit(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
