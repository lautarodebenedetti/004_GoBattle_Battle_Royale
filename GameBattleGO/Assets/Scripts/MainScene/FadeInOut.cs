using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour {
	private float transparence;
	public bool fadeOut;
	public float step = 0.01f;

	void Start () {
		//transparence = 1;	
	}
	
	// Update is called once per frame
	void Update () {
		transparence = Mathf.Clamp (transparence, 0, 1);
		if (fadeOut)
			transparence += step;
		else
			transparence -= step;
		GetComponent<CanvasGroup>().alpha = transparence;
	}

	public float getTransparence{
		get 
		{
			return transparence;
		}
	}
}
