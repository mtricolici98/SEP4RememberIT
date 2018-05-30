using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SequenceManager : MonoBehaviour {
	
	public SpriteAtlas atlas;
	public GameObject seqPanel;
	public GameObject seqMainPanel;
	private Component[] images;

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
		for (int i = 1; i <= seq.Count; i++) {
			((Image)	images [i]).sprite = atlas.GetSprite (seq [i-1]);
			((Image)	images [i]).gameObject.SetActive (true);
		}

		for (int i = seq.Count+1; i < images.Length; i++) {
			((Image)	images [i]).gameObject.SetActive (false);
		}

	}

	void StopSeq(){
		seqMainPanel.gameObject.SetActive (false);
	}
}
