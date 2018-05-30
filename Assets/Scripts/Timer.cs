using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public delegate void SeqTimerDone ();
	public static event SeqTimerDone stopSeqDisp;
	public delegate void GameTimer(float val);
	public static event GameTimer reportTimeLeft;
	public delegate void GameTimerDone(float val);
	public static event GameTimerDone reportTimeEnd;
	public delegate void NoMoreTime();
	public static event NoMoreTime timeEnd;




	void OnEnable(){

		//GameMaker.roundStart += StartGame;
		SetManager.sendSequence += StartSequenceTimer;
		SetManager.setFinished += StopGameTimer;
		UIScript.hasToFinish += StopGameTimer;
	}

	void OnDisable(){

		//	GameMaker.roundStart -= StartGame;
		SetManager.sendSequence -= StartSequenceTimer;
		SetManager.setFinished -= StopGameTimer;
		UIScript.hasToFinish -= StopGameTimer;
	}

	float currCountdownValue;
	public IEnumerator StartCountdownSeq(float countdownValue = 5)
	{
		currCountdownValue = countdownValue;

		while (currCountdownValue > 0)
		{
			reportTimeLeft (currCountdownValue);
			Debug.Log (currCountdownValue);
			yield return new WaitForSeconds(1.0f);
			currCountdownValue--;

		}
		stopSeqDisp ();
		StartCoroutine (StartCountdownGame ());
	}


	public IEnumerator StartCountdownGame(float countdownValue = 30)
	{
		
		currCountdownValue = countdownValue;

		while (currCountdownValue > 0)
		{
			Debug.Log (currCountdownValue);
			reportTimeLeft (currCountdownValue);
			yield return new WaitForSeconds(1.0f);
			currCountdownValue--;

		}
		timeEnd ();
		reportTimeEnd (0f);
	}


	void StartSequenceTimer(List<string> seq){
		StartCoroutine (StartCountdownSeq ());
	}

	void StopGameTimer(){
		reportTimeEnd (currCountdownValue);
		StopAllCoroutines ();
	}
}
