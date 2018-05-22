using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SetManager : MonoBehaviour {


    [SerializeField]
    private SpriteAtlas atlas;
    private Component[] childern;
    [SerializeField]
    private GameObject imageset;
	private List<string> sequence;
	private RandomManager rm;
	int i= 0;
    // Use this for initialization
    void Start () {
        childern = imageset.GetComponentsInChildren<SpriteRenderer>();
		rm = new RandomManager ();
		GetNewSequence (10);
    }
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("space")){
			
			ShowNewSet (sequence [i]);
			//i++;
		}
	}


	void ShowNewSet(string item){
		List<string> set = rm.GetItemSet (item);

		int j = 0;
	
		foreach(SpriteRenderer sr in childern)
		{
			
			sr.sprite = atlas.GetSprite(set[j]);
			if (set [j] == item) {
				sr.gameObject.name = set [j] + "right";
			} else
				sr.gameObject.name = set [j];
			j++;
		}
		i++;
	}

	void GetNewSequence(int length){
		sequence = rm.GetSequence (length);
	}

	public int getSetCount(){
		return i;
	}
}
