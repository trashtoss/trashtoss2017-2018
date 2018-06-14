using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life_Bins_Counter : MonoBehaviour {
	private Image myImage;
	public int myLimit;
	// Use this for initialization
	void Start () {
		myImage = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if( difficultySettings.landfillCounter >= myLimit)
			myImage.color = new Color(0,0,0,1);
	}
}
