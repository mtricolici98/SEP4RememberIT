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
	private RandomManager rm;
	//Setting up delegates for when the game finishes;
	public delegate void SetFinished ();
	public static event SetFinished setFinished;
	public delegate void GetSequence(List<string> seq);
	public static event GetSequence sendSequence;


	int i= 0;
    // Use this for initialization
    void Start () {
		StartGame ();
        childern = imageset.GetComponentsInChildren<SpriteRenderer>();
		rm = new RandomManager ();
		GetNewSequence (10);
		change ();
    }


	void StartGame(){
		imageset = Instantiate (imageprefab);
	}

	// Update is called once per frame
	void Update () {
		
	
	}

	void OnEnable(){
		ScoreManager.change+= change;
	}

	void OnDisable(){
		ScoreManager.change -= change;
	}
	// Update is called once per frame


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
