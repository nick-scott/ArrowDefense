using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public enum AudioChannel {Master, Sfx, Music};
	public float masterVolumePercent { get; private set; }
	public float sfxVolumePercent { get; private set; }
	public float musicVolumePercent { get; private set; }
	AudioSource _audio;
	public static AudioManager instance;

	public void Awake(){
		if( instance != null){
			Destroy (gameObject);
		}
		else{
			instance = this;
			DontDestroyOnLoad (gameObject);

			masterVolumePercent = PlayerPrefs.GetFloat ("MasterVolume", 1f);
			sfxVolumePercent = PlayerPrefs.GetFloat ("SfxVolume", 1f); 
			musicVolumePercent = PlayerPrefs.GetFloat ("MusicVolume", 1f);
		}
	}

	public void SetVolume(float volumePercent, AudioChannel channel){
		switch(channel){
		case AudioChannel.Master:
			masterVolumePercent = volumePercent;
			break;
		case AudioChannel.Sfx:
			sfxVolumePercent = volumePercent;
			break;
		case AudioChannel.Music:
			musicVolumePercent = volumePercent;
			break;
		}

		PlayerPrefs.SetFloat ("MasterVolume", masterVolumePercent);
		PlayerPrefs.SetFloat ("SfxVolume", sfxVolumePercent);
		PlayerPrefs.SetFloat ("MusicVolume", musicVolumePercent);
		PlayerPrefs.Save ();
		Debug.Log ("New volume value for:" + channel + " at:" +  volumePercent + " .Channel values: Master:" + masterVolumePercent + " SFX:" + sfxVolumePercent + " Music:" + musicVolumePercent);
	}

	public void PlayOneSound(AudioSource audioSource, AudioClip clip){
		_audio = audioSource;
		_audio.clip = clip;
		_audio.PlayOneShot(_audio.clip, sfxVolumePercent * masterVolumePercent);
	}

	public void PlayRandomSound(AudioSource audioSource, AudioClip[] clipArray, float delay){
		_audio = audioSource;
		_audio.clip = clipArray [Random.Range (0, clipArray.Length)];
		if (delay > 0f){
			_audio.volume = (sfxVolumePercent * masterVolumePercent);
			_audio.PlayDelayed (delay);
		}
		else {
			_audio.PlayOneShot(_audio.clip, sfxVolumePercent * masterVolumePercent);
		}
	}
}
