using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

enum SpriteTypes { item1, item2 , item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20}

public class AtlasProcessor : MonoBehaviour {



    [SerializeField]
    private SpriteAtlas atlas;

    List<string> sequence = new List<string>();
    int i = 0;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        //   sr.sprite = atlas.GetSprite(GetRandom());
        sequence = GetSequence();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            sr.sprite = atlas.GetSprite(sequence[i]);
            i++;
        }
	}


    List<string> GetSequence()
    {
        bool over = false;
        Array values = Enum.GetValues(typeof(SpriteTypes));
        List<string> list = new List<string>();
        int itemsAdded = 0;
        string randomSprite;
        System.Random random = new System.Random();
        while (!over) {
            randomSprite = values.GetValue(random.Next(values.Length)).ToString();
            if (!list.Contains(randomSprite) && itemsAdded<20)
            {
                list.Add(randomSprite);
                itemsAdded++;
            } else if (itemsAdded == 20)
            {
                over = true;
            }

            }
        Debug.Log("Sequence generated");
        return list;
        
    }

   


    

}
