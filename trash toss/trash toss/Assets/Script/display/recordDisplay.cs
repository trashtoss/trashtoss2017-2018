using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class recordDisplay : MonoBehaviour {

	Text text;
    List<int>[] table;

	// Use this for initialization
	void Start()
	{
        /*
		text = GetComponent<Text>();
		string str = "on this level, you threw: \n";
		foreach (string item in difficultySettings.playRecord) {
			str += item + "   ";
		}
		str += "\n\n\n\non this level, you failed to recycle: \n";
		foreach (string item in difficultySettings.failedRecord) {
			str += item + "   ";
		}
		text.text = str;
        */
	}

	// Update is called once per frame
	void Update()
	{
	}
}
