using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour {

	public GameObject titleMenu;
	public GameObject settingsMenu;

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
}
