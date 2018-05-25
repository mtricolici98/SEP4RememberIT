using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaker : MonoBehaviour {
	int score ;
	float timedone;
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
		DontDestroyOnLoad (this.gameObject);
	}

	void Start(){
	//StartGame (10);
	}

	void OnEnable(){
		
		SetManager.setFinished += finish;
		ScoreManager.notifyScore += getScore;
		SetManager.sendSequence += Sequence;
		Timer.reportTimeLeft += setFinalTime;
		Timer.timeEnd += finish;
	}

	

	void OnDisable(){
		SetManager.setFinished -= finish;
		ScoreManager.notifyScore -= getScore;
		SetManager.sendSequence -= Sequence;
		Timer.reportTimeLeft += setFinalTime;
		Timer.timeEnd -= finish;
	}



	public void StartGame(int seqlen){
		roundStart (seqlen);
	}

	void finish(){
		if (timedone == 0f)
			timedone = 1f;
		Debug.Log ("Start endscreen");
		Debug.Log (score * timedone + "Final Score");
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

	void setFinalTime(float val){
		timedone = val;
	}
}
