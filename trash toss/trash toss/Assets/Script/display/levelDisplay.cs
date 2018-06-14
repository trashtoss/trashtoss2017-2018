using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelDisplay : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
		string level = "LEVEL  " + difficultySettings.levelCounter;
		text.text = level;
	}

	// Update is called once per frame
	void Update()
	{
	}
}
