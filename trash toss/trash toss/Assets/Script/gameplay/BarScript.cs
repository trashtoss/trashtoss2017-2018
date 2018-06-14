using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MONEY SYSTEM: fills money bar based on totalAccumulatedMoney
public class BarScript :MonoBehaviour {
    // Serial is what allows to see on the bar when private
    [SerializeField]
	private Image content;
	int score = difficultySettings.score;
    double currentMoney = difficultySettings.totalAccumulatedMoney;

	// Use this for initialization
	void Start () {
		content.fillAmount = 0.5f; //fill money bar half way
    }

    // Update is called once per frame
    void Update() {
        if (difficultySettings.isStarted & !difficultySettings.isCompleted) {
            
            // Not sure what this does but the game breaks without it
			if (score != difficultySettings.score) {
				if (throwTrash.correctCollision == true && throwTrash.tagHolder != null) {
                    barFill(throwTrash.tagHolder.tag);
                    Destroy(throwTrash.tagHolder);
                }
			}
            
            // Fills money bar based on accumulated money
            if (currentMoney != difficultySettings.totalAccumulatedMoney) {
                // If total money went up
                if (currentMoney < difficultySettings.totalAccumulatedMoney) {
                    content.fillAmount = content.fillAmount + 0.1f;
                    currentMoney = difficultySettings.totalAccumulatedMoney;
                    print("money bar increase! $$$$$$$$");
                // If total money went down
                } else if (currentMoney > difficultySettings.totalAccumulatedMoney) {
                    content.fillAmount = content.fillAmount - 0.1f;
                    currentMoney = difficultySettings.totalAccumulatedMoney;
                    print("money bar decrease :( ");
                }
            }
            
            // If money bar gets to 0, end the game
            if (content.fillAmount <= 0) { 
                difficultySettings.gameOvered = true;
            }
		}
    }

    public void barFill(string tag) {
        
        //content.fillAmount -= Time.deltaTime * difficultySettings.barDropRate;
        switch (tag) {
            case "Plastic":
                //content.fillAmount = content.fillAmount + difficultySettings.barGainRatePlastic;
                score = difficultySettings.score;
                break;
            case "Glass":
                //content.fillAmount = content.fillAmount + difficultySettings.barGainRateGlass;
                score = difficultySettings.score;
                break;
            case "Metal":
                //content.fillAmount = content.fillAmount + difficultySettings.barGainRateMetal;
                score = difficultySettings.score;
                break;
            case "Paper":
                //content.fillAmount = content.fillAmount + difficultySettings.barGainRatePaper;
                score = difficultySettings.score;
                break;
            case "composite":
                //content.fillAmount = content.fillAmount + difficultySettings.barGainRateCompost;
                score = difficultySettings.score;
                break;
            default:
                break;
        }
    }
}
