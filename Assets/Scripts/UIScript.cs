using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

		
	public Button playButton;
	public Sprite musicOn;
	public Sprite musicOff;
	public Button pauseButton;
	public Text timeleft;
	public GameObject pauseMenu;
	public Button btnEasy;
	public Button btnMedium;
	public Button btnHard;
	public GameObject menuPanel;
	public GameObject difficultyPanel;
	public GameObject seqPanel;
	public GameObject EndScreen;
	public Button endGoToMM;
	public Button endPlayAgain;
	public Button resumeButton;
	public Button goToMainMenuButton;
	public Button quitPauseButton;
	public Button quitMMButton;
	public Button muteButton;
	public Button instLeft;
	public Button instRight;
	public Button instBack;
	public GameObject InstMenu;
	public Image instImage;
	public List<Sprite> instImages;
	private int instIdex;
	public Button instButton;










	public delegate void FinishEarly ();
	public static event FinishEarly hasToFinish;
	public delegate void ToggleMute();
	public static event ToggleMute toggleMute;
	public delegate void TogglePause();
	public static event TogglePause togglePause;
	bool muted =false;
	private int lastdiff;
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
		endGoToMM.onClick.AddListener (EndGoToMM);
		endPlayAgain.onClick.AddListener (PlayAgain);
		instButton.onClick.AddListener (ShowInst);
		instBack.onClick.AddListener (instBackAct);
		instLeft.onClick.AddListener (instPrev);
		instRight.onClick.AddListener (instNext);
		instIdex = 0;
	}

	void OnEnable(){
		Timer.stopSeqDisp += ShowPauseButton;
		SetManager.setFinished += displayEndScreen;
		Timer.timeEnd += displayEndScreen;
		Timer.reportTimeLeft += setTimeLeft;
	}
	void OnDisable(){
		Timer.stopSeqDisp -= ShowPauseButton;
		SetManager.setFinished -= displayEndScreen;
		Timer.timeEnd -= displayEndScreen;
		Timer.reportTimeLeft -= setTimeLeft;
	}


	void StartGame(string diff){
		//SceneManager.LoadScene ("GameMainScene");
		switch(diff){
		case "easy" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (5);
				lastdiff = 5;
				timeleft.gameObject.SetActive (true);
				//pauseButton.gameObject.SetActive (true);

			}

			break;
		case "medium" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (8);
				lastdiff = 8;
				timeleft.gameObject.SetActive (true);
				//pauseButton.gameObject.SetActive (true);

			}

			break;
		case "hard" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (11);
				lastdiff = 11;
				timeleft.gameObject.SetActive (true);
			//	pauseButton.gameObject.SetActive (true);

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
		timeleft.gameObject.SetActive (false);
		togglePause ();
	}

	void ResumeGame(){
		pauseMenu.SetActive (false);
		pauseButton.gameObject.SetActive (true);
		Time.timeScale = 1f;
		timeleft.gameObject.SetActive (true);
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
		Image muteImg = muteButton.gameObject.GetComponent<Image> ();
		if (!muted) {
			muteImg.sprite = musicOn;
			muted = true;
		} else {
			muteImg.sprite = musicOff;
			muted = false;
		}
	}



	void ShowPauseButton(){
		pauseButton.gameObject.SetActive (true);
	}

	void PlayAgain(){
		GameMaker.Instance.StartGame (lastdiff);
		timeleft.gameObject.SetActive (true);
		EndScreen.SetActive (false);
	}

	void displayEndScreen(){
		EndScreen.SetActive (true);
		timeleft.gameObject.SetActive (false);
	}

	void EndGoToMM(){
		menuPanel.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		EndScreen.SetActive (false);
	}


	void setTimeLeft(float val){
		timeleft.text = val.ToString ();
	
	}

	void ShowInst(){
		InstMenu.SetActive (true);
		instImage.sprite = instImages [instIdex];
		instLeft.gameObject.SetActive (false);
		instRight.gameObject.SetActive (true);
	}


	void instNext(){
		instIdex += 1;
		instImage.sprite = instImages [instIdex];
		if (instIdex == 0) {
			instLeft.gameObject.SetActive (false);
			instRight.gameObject.SetActive (true);
		} else if (instIdex == 2) {
			instLeft.gameObject.SetActive (true);
			instRight.gameObject.SetActive (false);
		} else {
			instLeft.gameObject.SetActive (true);
			instRight.gameObject.SetActive (true);
		}
	}

	void instPrev(){
		instIdex -= 1;
		instImage.sprite = instImages [instIdex];
		if (instIdex == 0) {
			instLeft.gameObject.SetActive (false);
			instRight.gameObject.SetActive (true);
		} else if (instIdex == 2) {
			instLeft.gameObject.SetActive (true);
			instRight.gameObject.SetActive (false);
		} else {
			instLeft.gameObject.SetActive (true);
			instRight.gameObject.SetActive (true);
		}
	}

	void instBackAct(){
		InstMenu.SetActive (false);
		instIdex = 0;
		instLeft.gameObject.SetActive (false);
		instRight.gameObject.SetActive (true);
	}

}
