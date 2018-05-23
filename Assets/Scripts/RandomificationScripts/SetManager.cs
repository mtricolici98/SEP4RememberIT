using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SetManager : MonoBehaviour {


    [SerializeField]
    private SpriteAtlas atlas;
    private Component[] childern;
    [SerializeField]
    private GameObject imageprefab;
	private List<string> sequence;
	private GameObject imageset;
	private RandomManager rm  = new RandomManager ();
	int i= 0;
	//Setting up delegates for when the game finishes;
	public delegate void SetFinished ();
	public static event SetFinished setFinished;
	public delegate void GetSequence(List<string> seq);
	public static event GetSequence sendSequence;

	void OnEnable(){
		ScoreManager.change+= change;
		GameMaker.roundStart += StartGame;
	}

	void OnDisable(){
		ScoreManager.change -= change;
		GameMaker.roundStart -= StartGame;
	}
		
	void StartGame(int seqlen){
		
		imageset = Instantiate (imageprefab);
		childern = imageset.GetComponentsInChildren<SpriteRenderer>();
		GetNewSequence (seqlen);
		ShowNewSet (sequence[0]);
		//change ();
	}
		

	void ShowNewSet(string item){
		

		int j = 0;
		if (i < sequence.Count) {
			List<string> set = rm.GetItemSet (item);
			foreach (SpriteRenderer sr in childern) {
			
				sr.sprite = atlas.GetSprite (set [j]);
				if (set [j] == item) {
					sr.gameObject.name = set [j] + "right";
				} else
					sr.gameObject.name = set [j];
				j++;
			}
			i++;
			Debug.Log ("current I " + i);
		} else if (i==sequence.Count+1){
			Debug.Log ("Set is over ");
		
		
		}

	}


	void GetNewSequence(int length){
		sequence = rm.GetSequence (length);
		sendSequence (sequence);
	}

	public int getSetCount(){
		return i;
	}

	void change(){
		
		if (i == sequence.Count) {
			Debug.Log ("Cant change anymore");
			setFinished ();
			deleteSet ();

		} else {ShowNewSet (sequence [i]);
		}
	}


	void deleteSet(){
		Destroy (imageset);
	}
}
