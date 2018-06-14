using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondStar : MonoBehaviour {

    public static int DestroyedCount;
    // Use this for initialization
    void Start () {
        

    }

 	
	// Update is called once per frame
	void Update () {
        switch (difficultySettings.tutorialLevelCounter)
        {
            case 1:
                if (DestroyedCount > difficultySettings.levelGoal + 6)
                    gameObject.SetActive(false);
                break;
            case 2:
                if (DestroyedCount > difficultySettings.levelGoal + 6)
                    gameObject.SetActive(false);
                break;
            case 3:
                if (DestroyedCount > difficultySettings.levelGoal + 6)
                    gameObject.SetActive(false);
                break;
            case 4:
                if (DestroyedCount > difficultySettings.levelGoal + 6)
                    gameObject.SetActive(false);
                break;
            case 5:
                if (DestroyedCount > difficultySettings.levelGoal + 6)
                    gameObject.SetActive(false);
                break;

        }    
    }
}
