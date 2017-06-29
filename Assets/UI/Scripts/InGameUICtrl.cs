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
	public Slider[] volumeSliders;

	public void Start(){
		volumeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volumeSliders [1].value = AudioManager.instance.sfxVolumePercent;
		volumeSliders [2].value = AudioManager.instance.musicVolumePercent;
	}

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

	public void SetMasterVolume(){
		AudioManager.instance.SetVolume (volumeSliders[0].value, AudioManager.AudioChannel.Master);
	}

	public void SetSfxVolume(){
		AudioManager.instance.SetVolume (volumeSliders[1].value, AudioManager.AudioChannel.Sfx);
	}

	public void SetMusicVolume(){
		AudioManager.instance.SetVolume (volumeSliders[2].value, AudioManager.AudioChannel.Music);
	}
}
