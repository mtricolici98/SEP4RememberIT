using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaker : MonoBehaviour {
	int score ;
	float timedone;
	public Text currentScore;
	public Text highscore;
	public Text CorrectAnswers;
	public static GameMaker Instance {get;set;}
	public delegate void StartRound(int seqlen);
	public static event StartRound roundStart;
	private PersitanceScript data;
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
		data = new PersitanceScript ();
	}

	void OnEnable(){
		

		ScoreManager.notifyScore += getScore;

		Timer.reportTimeEnd += setFinalTime;
		Timer.timeEnd += finish;

	}

	

	void OnDisable(){
		
		ScoreManager.notifyScore -= getScore;

		Timer.reportTimeEnd -= setFinalTime;
		Timer.timeEnd -= finish;
	}



	public void StartGame(int seqlen){
		roundStart (seqlen);
	}

	void finish(){
		
		if (timedone == 0f)
			timedone = 1f;
		Debug.Log ("Start endscreen");
		CorrectAnswers.text = score.ToString ();
		Debug.Log (score * timedone + "Final Score");
		float currscore = (score * timedone);
		data.Load ();
		if (data.score >= currscore) {
			currentScore.text = currscore.ToString();
			highscore.text = data.score.ToString();
			data.Save (data.score);
		} else {
			currentScore.text = currscore.ToString();
			highscore.text = currscore.ToString();
			data.Save (currscore);
		}


	}

	void getScore(int sc){
		score = sc;

	}



	void setFinalTime(float val){
		timedone = val;
		finish ();
	}




}
