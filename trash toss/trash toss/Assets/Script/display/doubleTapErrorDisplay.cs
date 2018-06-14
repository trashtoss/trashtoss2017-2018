using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doubleTapErrorDisplay : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		string doubleTapError = "Double-Tap" + "\n" + "to Separate!";
		text.text = doubleTapError;
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//When two step item is thrown in bin, this text is displayed.
		if(difficultySettings.dTapError){
			text.enabled = true;
			Invoke ("DisableText", 3f);
		}
		difficultySettings.dTapError = false;
	}

	public void DisableText(){
		text.enabled = false;
	}
}
