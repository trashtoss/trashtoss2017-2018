using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goalDisplay : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
		string goal = "Goal: " + difficultySettings.levelGoal + " items";
		text.text = goal;
	}

	// Update is called once per frame
	void Update()
	{
	}
}
