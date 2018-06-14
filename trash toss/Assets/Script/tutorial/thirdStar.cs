using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (difficultySettings.tutorialLevelCounter)
        {
            case 1:
                if (secondStar.DestroyedCount > difficultySettings.levelGoal + 3)
                    gameObject.SetActive(false);
                break;
            case 2:
                if (secondStar.DestroyedCount > difficultySettings.levelGoal + 3)
                    gameObject.SetActive(false);
                break;
            case 3:
                if (secondStar.DestroyedCount > difficultySettings.levelGoal + 3)
                    gameObject.SetActive(false);
                break;
            case 4:
                if (secondStar.DestroyedCount > difficultySettings.levelGoal + 3)
                    gameObject.SetActive(false);
                break;
            case 5:
                if (secondStar.DestroyedCount > difficultySettings.levelGoal + 3)
                    gameObject.SetActive(false);
                break;

        }

    }
}
