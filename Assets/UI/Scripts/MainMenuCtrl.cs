using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCtrl : MonoBehaviour {

	public GameObject titleMenu;
	public GameObject settingsMenu;
	public Slider[] volumeSliders;

	public void Start(){
		volumeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volumeSliders [1].value = AudioManager.instance.sfxVolumePercent;
		volumeSliders [2].value = AudioManager.instance.musicVolumePercent;
	}

	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void SettingsMenu(){
		titleMenu.SetActive (false);
		settingsMenu.SetActive (true);
	}

	public void ReturnToTitleMenu(){
		settingsMenu.SetActive (false);
		titleMenu.SetActive (true);
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
