using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		OnTouch.hasClicked += validateAnswer;
	}
	void onEnable(){
		OnTouch.hasClicked += validateAnswer;
	}

	void onDisable(){
		OnTouch.hasClicked -= validateAnswer;
	}
	// Update is called once per frame
	void Update () {
		
	}

	void validateAnswer(string item){
		Debug.Log ("EVENT ITEM "+  item);
	}

}
