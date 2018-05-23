using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound{
	public string name;
	public AudioClip clip;
	private AudioSource source;
	[Range(0f, 1f)]
	public float volume = 0.7f;
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

}
 	


public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	 // to be editable from the inspectiors but not accesable from scripts :)

	[SerializeField]
	public Sound[] sounds;

	void Awake(){
		if (instance != null) {
			Debug.LogError ("More than one AudioManager in the scene ");
		} else {
			instance = this;
		}
	}

	void Start(){
		for (int i = 0; i < sounds.Length; i++) {
			GameObject _go = new GameObject ("Sound_ " + i + "_" + sounds [i].name);
			sounds [i].setSource (_go.AddComponent<AudioSource> ());
		}
		PlaySound ("toolur_Srwxer.mp3");

	}

	public void PlaySound(string _name){
		for (int i = 0; i < sounds.Length; i++) {
			if (sounds [i].name == _name) {
				sounds [i].Play ();
				return;
			}

		}
		
	}





	}

