using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SequenceManager : MonoBehaviour {
	[SerializeField]
	private SpriteAtlas atlas;
	public GameObject seqPanel;
	public GameObject seqMainPanel;
	private Component[] images;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnEnable(){

		//GameMaker.roundStart += StartGame;
		SetManager.sendSequence += StartGame;
		Timer.stopSeqDisp += StopSeq;
	}

	void OnDisable(){

	//	GameMaker.roundStart -= StartGame;
		SetManager.sendSequence += StartGame;
		Timer.stopSeqDisp += StopSeq;
	}
	void StartGame(List<string> seq){
		seqMainPanel.SetActive (true);
		images = seqPanel.GetComponentsInChildren<Image> (includeInactive: true);
		
		//Image tmp = null;
		Debug.Log("List size" + images.Length);
		for (int i = 1; i <= seq.Count; i++) {
			((Image)	images [i]).sprite = atlas.GetSprite (seq [i-1]);
			((Image)	images [i]).gameObject.SetActive (true);
		}

	}

	void StopSeq(){
		seqMainPanel.gameObject.SetActive (false);
	}
}
