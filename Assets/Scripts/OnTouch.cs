using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour {

    private RuntimePlatform platform = Application.platform;
	public delegate void Clicked (string item);
	public static event Clicked hasClicked;
    void Update()
    {
        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
        }
    }

    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {
            Debug.Log(hit.transform.gameObject.name);
			if(hasClicked!=null)hasClicked(hit.transform.gameObject.name);
        }
    }
}
