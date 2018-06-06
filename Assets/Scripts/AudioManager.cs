using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound{
	public string name;
	public AudioClip clip;
	private AudioSource source;
	public bool PlayOnAwake;
	public bool setLoop;
	[Range(0f, 1f)]
	public float volume = 0.5f;
	[Range(0.5f, 1.5f)]
	public float pitch = 1f;

	public void setSource(AudioSource _source){
		source = _source;
		source.clip = clip;
		source.loop = setLoop;
		source.playOnAwake = PlayOnAwake;
		source.Play ();

	}
	public void Play(){
		
		source.volume = volume;
		//Debug.Log ("I GOT HERE");
		source.pitch=pitch;
		source.Play ();

	}

	public void Mute(){
		source.volume = 0f;
		source.pitch=0f;
	}
	public void unMute(){
		source.volume = 0.5f;
		source.pitch=1f;
	}



}
 	


public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	void OnEnable(){
		UIScript.toggleMute += toggleMute;
		OnTouch.hasClicked += PlayClickSound;
	}
	void OnDisable(){
		UIScript.toggleMute -= toggleMute;
		OnTouch.hasClicked -= PlayClickSound;
	}
	[SerializeField]
	public Sound[] sounds;
	private bool muted;
	void Awake(){
		if (instance != null) {
			Debug.LogError ("More than one AudioManager in the scene ");
		} else {
			instance = this;
		}
		muted = false;
	}
	GameObject _go ;
	void Start(){
		
			_go = new GameObject ("Sound" + sounds [0].name);
		for (int i = 0; i < sounds.Length; i++) {
			sounds[i].setSource(_go.AddComponent<AudioSource>());
		}
		PlaySound ("background");


	}

	public void PlaySound(string _name){
		for (int i = 0; i < sounds.Length; i++) {
			if (sounds [i].name == _name) {
			//	sounds[i].setSource(_go.AddComponent<AudioSource>());
				sounds [i].Play ();


				return;
			}

		}
		
	}

	void toggleMute(){
		
		if (!muted) {
			for (int i = 0; i < sounds.Length; i++) {

				sounds [i].Mute ();
				Debug.Log ("MUTING");
				muted = true;
			}

		} else if (muted) {
			for (int i = 0; i < sounds.Length; i++) {
				sounds [i].unMute ();
				Debug.Log ("UNMUTING");
				muted = false;
			}

		}

	}



	void PlayClickSound(string args){
		PlaySound ("click");
		//Debug.Log ("Playing Click");
	}



	}

