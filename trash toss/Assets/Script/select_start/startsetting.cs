using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startsetting : MonoBehaviour {
    public difficultySettings settings;
	// Use this for initialization
	void Start () {
        //int goal, float gainGla, float gainPla, float gainMet, float gainPaper, float gainComp,
        //float drop, float speed, int lives, float gap
		Time.timeScale = 1;
		settings = new difficultySettings();

		switch (difficultySettings.levelCounter)
		{
		case 1:
			settings.setDifficulty("low");
			break;
		case 2:
			settings.setDifficulty("medium low");
			break;
		case 3:
			settings.setDifficulty("medium");
			break;
		case 4:
			settings.setDifficulty("medium high");
			break;
		case 5:
			settings.setDifficulty("high");
			break;
		default:
			settings.setDifficulty("extreme");
			break;
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
