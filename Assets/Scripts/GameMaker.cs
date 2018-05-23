using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaker : MonoBehaviour {
	int score ;

	public static GameMaker Instance {get;set;}
	public delegate void StartRound(int seqlen);
	public static event StartRound roundStart;
	private List<string> currentSequence;
	void Awake(){
		if (Instance == null) {
			Instance = this;
		} else {
			Debug.Log ("Multiple Gamemakers");
		}
	}

	void Start(){
	//	StartGame (10);
	}

	void OnEnable(){
		
		SetManager.setFinished += finish;
		ScoreManager.notifyScore += getScore;
		SetManager.sendSequence += Sequence;
	}

	

	void OnDisable(){
		SetManager.setFinished -= finish;
		ScoreManager.notifyScore -= getScore;
		SetManager.sendSequence -= Sequence;
	}



	void StartGame(int seqlen){
		roundStart (seqlen);
	}

	void finish(){
		Debug.Log ("Start endscreen");
		Debug.Log ("Save Score");
	}

	void getScore(int sc){
		score = sc;
		Debug.Log ("Final Score " + score);
	}

	void Sequence(List<string> sc) {
		currentSequence = sc;
		Debug.Log (sc.ToString());
	}
}
