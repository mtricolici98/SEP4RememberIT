using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

enum SpriteTypes { item1, item2 , item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20}

public class AtlasProcessor : MonoBehaviour {



    [SerializeField]
    private SpriteAtlas atlas;

    private Component[] childern;

    
    static System.Random random = new System.Random();
    Array values;

    List<string> sequence = new List<string>();
  
    int i = 0;
   // private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
     //   sr = GetComponent<SpriteRenderer>();
        //   sr.sprite = atlas.GetSprite(GetRandom());
        values = Enum.GetValues(typeof(SpriteTypes));
        sequence = GetSequence();
        Debug.Log("Instantiated Random");
        childern = GetComponentsInChildren<SpriteRenderer>();
        Debug.Log("Start Finished");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("SpaceHit");
            List<string> set = GetItemSet(sequence[i]);
            int j = 0;
            Debug.Log(sequence[i]);
            foreach(SpriteRenderer sr in childern)
            {
                Debug.Log(set[j]);
                sr.sprite = atlas.GetSprite(set[j]);
                j++;
            }
            i++;
        }
	}


    List<string> GetSequence()
    {
        Debug.Log("Starting Sequence");
        bool over = false;
        List<string> list = new List<string>();
        int itemsAdded = 0;
        string randomSprite;
       
        while (!over) {
            randomSprite = values.GetValue(random.Next(values.Length)).ToString();
            if (!list.Contains(randomSprite) && itemsAdded<20)
            {
                list.Add(randomSprite);
                itemsAdded++;
                Debug.Log("Sequence Item Added");
            } else if (itemsAdded == 20)
            {
                over = true;
            }

            }
        Debug.Log("Sequence generated");
        return list;
        
    }

    List<string> GetItemSet(string sequenceSprite)
    {
        Debug.Log("ItemSetGenerated");
        List<string> set = new List<string>();
        bool over = false;
        string randomSprite;
        set.Add(sequenceSprite);
        int itemsAdded = 0;
        while (!over)
        {
            randomSprite = values.GetValue(random.Next(values.Length)).ToString();
            if (!set.Contains(randomSprite) && itemsAdded < 2)
            {
                set.Add(randomSprite);
                itemsAdded++;
            }
            else if (itemsAdded == 2)
            {
                over = true;
            }
        }
        Shuffle(set);
        

       return set;
    }

     static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }






}
