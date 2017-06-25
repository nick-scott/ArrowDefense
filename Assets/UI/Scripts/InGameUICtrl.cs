using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUICtrl : MonoBehaviour {
	
	public bool isPaused;
	public GameObject inGameUI;
	public GameObject pauseMenu;
	public GameObject settingsMenu;
	public Image pauseButtonImage;
	public Sprite cogImage;
	public Sprite pauseImage;

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
		pauseMenu.SetActive (true);
		pauseButtonImage.sprite = pauseImage;
	}

	public void Resume(){
		isPaused = false;
		pauseMenu.SetActive (false);
		pauseButtonImage.sprite = cogImage;
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
