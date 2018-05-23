using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {



	public Button btnEasy;
	public Button btnMedium;
	public Button btnHard;
	public GameObject menuPanel;
	public GameObject difficultyPanel;
	// Use this for initialization
	void Start () {
		Button btn1 = btnEasy.GetComponent<Button> ();
		Button btn2 = btnMedium.GetComponent<Button> ();
		Button btn3 = btnHard.GetComponent<Button> ();
		btn1.onClick.AddListener (delegate {
			StartGame ("easy");
		});
		btn2.onClick.AddListener (delegate {
			StartGame ("medium");
		});
		btn3.onClick.AddListener (delegate {
			StartGame ("hard");
		});
	}


			void StartGame(string diff){
		//SceneManager.LoadScene ("GameMainScene");
		switch(diff){
		case "easy" :{ 
				difficultyPanel.SetActive (false);
		GameMaker.Instance.StartGame (8);

			}

			break;
		case "medium" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (11);
			}

			break;
		case "hard" :{ 
				difficultyPanel.SetActive (false);
				GameMaker.Instance.StartGame (15);
			}

			break;
		default : 
			Debug.Log ("Problem");

			break;
		}



	}


}
