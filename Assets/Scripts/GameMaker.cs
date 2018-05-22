using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaker : MonoBehaviour {
	int score ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		
		SetManager.setFinished += finish;
		ScoreManager.notifyScore += getScore;
	}

	

	void OnDisable(){
		SetManager.setFinished -= finish;
		ScoreManager.notifyScore -= getScore;
	}



	void finish(){
		Debug.Log ("Start endscreen");
	}

	void getScore(int sc){
		score = sc;
		Debug.Log ("Final Score " + score);
	}
}
