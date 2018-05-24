using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound{
	public string name;
	public AudioClip clip;
	private AudioSource source;
	[Range(0f, 1f)]
	public float volume = 0.5f;
	[Range(0.5f, 1.5f)]
	public float pitch = 1f;

	public void setSource(AudioSource _source){
		source = _source;
		source.clip = clip;
		source.Play ();

	}
	public void Play(){
		source.volume = volume;
		source.pitch=pitch;

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

	 // to be editable from the inspectiors but not accesable from scripts :)
	void OnEnable(){
		UIScript.toggleMute += toggleMute;
	}
	void OnDisable(){
		UIScript.toggleMute -= toggleMute;
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

	void Start(){
		for (int i = 0; i < sounds.Length; i++) {
			GameObject _go = new GameObject ("Sound_ " + i + "_" + sounds [i].name);
			sounds [i].setSource (_go.AddComponent<AudioSource> ());
		}
		PlaySound ("bensound-deepblue.mp3");

	}

	public void PlaySound(string _name){
		for (int i = 0; i < sounds.Length; i++) {
			if (sounds [i].name == _name) {
				sounds [i].Play ();
				return;
			}

		}
		
	}

	void toggleMute(){
		Debug.Log ("MUTING");
		if (!muted) {
			for (int i = 0; i < sounds.Length; i++) {

				sounds [i].Mute ();
				muted = true;
			}
		} else if (muted) {
			for (int i = 0; i < sounds.Length; i++) {
				sounds [i].unMute ();
				muted = false;
			}
		}

	}





	}

