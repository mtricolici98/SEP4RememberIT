using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

		
	public Button playButton;
		
	public Button pauseButton;

	public GameObject pauseMenu;
	public Button btnEasy;
	public Button btnMedium;
	public Button btnHard;
	public GameObject menuPanel;
	public GameObject difficultyPanel;
	public GameObject seqPanel;
	public Button resumeButton;
	public Button goToMainMenuButton;
	public Button quitPauseButton;
	public Button quitMMButton;
	public Button muteButton;
	public delegate void FinishEarly ();
	public static event FinishEarly hasToFinish;
	public delegate void ToggleMute();
	public static event ToggleMute toggleMute;
	public delegate void TogglePause();
	public static event TogglePause togglePause;
	void Start()
	{	playButton.onClick.AddListener(ChangeToDiff);
		pauseButton.onClick.AddListener (PauseGame);
		btnEasy.onClick.AddListener (delegate {
			StartGame ("easy");
		});
		btnMedium.onClick.AddListener (delegate {
			StartGame ("medium");
		});
		btnHard.onClick.AddListener (delegate {
			StartGame ("hard");
		});
		resumeButton.onClick.AddListener (ResumeGame);
		goToMainMenuButton.onClick.AddListener (GoToMM);
		quitPauseButton.onClick.AddListener (quitGame);
		quitMMButton.onClick.AddListener (quitGame);
		muteButton.onClick.AddListener (mute);
	}

	void OnEnable(){
		Timer.stopSeqDisp += ShowPauseButton;
	}
	void OnDisable(){
		Timer.stopSeqDisp -= ShowPauseButton;
	}


	void StartGame(string diff){
		//SceneManager.LoadScene ("GameMainScene");
		switch(diff){
		case "easy" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (8);
				//pauseButton.gameObject.SetActive (true);

			}

			break;
		case "medium" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (11);
				//pauseButton.gameObject.SetActive (true);
				ActivateSeqPanel ();
			}

			break;
		case "hard" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (15);
			//	pauseButton.gameObject.SetActive (true);
				ActivateSeqPanel ();
			}

			break;
		default : 
			Debug.Log ("Problem");
			//pauseButton.SetActive (true);

			break;
		}
	}
	void ChangeToDiff()
	{

		menuPanel.SetActive (false);
		difficultyPanel.SetActive (true);
	}
	void PauseGame(){
		pauseMenu.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		Time.timeScale = 0f;
		togglePause ();
	}

	void ResumeGame(){
		pauseMenu.SetActive (false);
		pauseButton.gameObject.SetActive (true);
		Time.timeScale = 1f;
		togglePause ();
	}

	void GoToMM(){
		hasToFinish ();
		pauseMenu.SetActive (false);
		menuPanel.SetActive (true);
		Time.timeScale = 1f;
		togglePause ();
	}

	void quitGame(){
		Debug.Log ("QUITING");
		Application.Quit ();
	}

	void mute(){
		toggleMute ();
	}

	void ActivateSeqPanel(){
		seqPanel.SetActive (true);
		Debug.Log ("Actviating seq");
	}

	void ShowPauseButton(){
		pauseButton.gameObject.SetActive (true);
	}
}
