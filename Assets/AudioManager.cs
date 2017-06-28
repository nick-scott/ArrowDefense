using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	float sfxVolumePercent = 1;
	float musicVolumePercent = 1;
	AudioSource _audio;
	public static AudioManager instance;

	public void Awake(){
		instance = this;
	}

	public void PlayOneSound(AudioSource audioSource, AudioClip clip){
		_audio = audioSource;
		_audio.clip = clip;
		_audio.Play();
	}

	public void PlayRandomSound(AudioSource audioSource, AudioClip[] clipArray, float delay){
		_audio = audioSource;
		_audio.clip = clipArray [Random.Range (0, clipArray.Length)];
		if (delay > 0f){
			_audio.PlayDelayed (delay);
		}
		else {
			_audio.Play();
		}
	}
}
