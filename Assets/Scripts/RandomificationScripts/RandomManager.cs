using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager  {
    enum SpriteTypes { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20 }

	static System.Random random;
    Array values;

	public RandomManager()
    {
      
        values = Enum.GetValues(typeof(SpriteTypes));
		random = new System.Random();
    }



	public List<string> GetSequence(int length)
    {

        bool over = false;
        List<string> list = new List<string>();
        int itemsAdded = 0;
        string randomSprite;

        while (!over)
        {
            randomSprite = values.GetValue(random.Next(values.Length)).ToString();
			if (!list.Contains(randomSprite) && itemsAdded < length)
            {
                list.Add(randomSprite);
                itemsAdded++;

            }
			else if (itemsAdded == length)
            {
                over = true;
            }

        }

        return list;

    }

    public List<string> GetItemSet(string sequenceSprite)
    {

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
