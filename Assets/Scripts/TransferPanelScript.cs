using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TransferPanelScript : MonoBehaviour {


	[SerializeField] 	
	public Button button;
	[SerializeField] 	
	private GameObject panel;
	[SerializeField]
	public GameObject paneltwo;

		void Start()
		{
		
		
		
		button.onClick.AddListener(TaskOnClick);

		}

		void TaskOnClick()
		{
		
		paneltwo.SetActive (true);
		panel.SetActive (false);
		}

		void TaskWithParameters(string message)
		{
			//Output this to console when the Button is clicked
			Debug.Log(message);
		}
	}
 	
