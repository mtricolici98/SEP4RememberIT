using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public delegate void ChangeSet ();
	public static event ChangeSet change;
	public delegate void finalScore (int score);
	public static event finalScore notifyScore;

	private int score;
	// Use this for initialization


	void OnEnable(){
		OnTouch.hasClicked += validateAnswer;
		SetManager.setFinished += SendScore; 
		GameMaker.roundStart += NewScore;
		UIScript.hasToFinish += SendScore;
	}

	void OnDisable(){
		OnTouch.hasClicked -= validateAnswer;
		SetManager.setFinished -= SendScore; 
		GameMaker.roundStart -= NewScore;
		UIScript.hasToFinish -= SendScore;
	}


	void validateAnswer(string item){
		Debug.Log ("EVENT ITEM "+  item);
		if (item.Contains ("item") && item.Contains ("right")) {
			score++;

			Debug.Log ("Current Score " + score);
			nextSet ();
		} else if (item.Contains ("item")) {
			
			Debug.Log ("Current Score " + score);
			nextSet ();
		}
		Debug.Log ("Current Score " + score);
	}


	void nextSet(){
	
		if(change!=null)change();
	}

	void SendScore(){
	
		notifyScore (score);

	}

	void NewScore(int seqlen){
		score = 0;
	}
}
